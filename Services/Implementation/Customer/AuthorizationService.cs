using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using GenosStore.Model.Entity.User;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Entity.Users;
using GenosStore.Utility.Types.AuthRegister;

namespace GenosStore.Services.Implementation.Customer {
    public class AuthorizationService: IAuthorizationService {
        private IGenosStoreRepositories _repositories;
        private IUserService _userService;

        public AuthorizationService(IGenosStoreRepositories repositories, IUserService userService) {
            _repositories = repositories;
            _userService = userService;
        }

        public Tuple<AuthorizationStatus, User> Authorize(string login, string password) {
            if (!_userService.Exists(login)) {
                return new Tuple<AuthorizationStatus, User>(
                    AuthorizationStatus.DoesNotExist,
                    null
                );
            }

            var u = _userService.FindByEmail(login);
            if (u == null) {
                return new Tuple<AuthorizationStatus, User>(
                    AuthorizationStatus.DoesNotExist,
                    null
                );
            }

            if (u.UserType == UserType.LegalEntity) {
                var verify = _repositories
                             .Users
                             .LegalEntities
                             .Get(u.Id).IsVerified;
                if (!verify) {
                    return new Tuple<AuthorizationStatus, User>(
                        AuthorizationStatus.LegalEntityNotVerified,
                        null
                    );
                }
            }
            
            var checksum = _generateSHA256Checksum(password + u.Salt);

            if (checksum != u.PasswordHash) {
                return new Tuple<AuthorizationStatus, User>(
                    AuthorizationStatus.IncorrectPassword,
                    null
                );
            }
            
            return new Tuple<AuthorizationStatus, User>(
                AuthorizationStatus.Success,
                u
            );
            
        }

        public RegistrationStatus RegisterIndividual(IndividualEntityRegistrationData regData) {

            if (_userService.Exists(regData.Email)) {
                return RegistrationStatus.UserAlreadyExists;
            }

            if (!_validateEmail(regData.Email)) {
                return RegistrationStatus.InvalidEmail;
            }
            
            if (!_validatePhoneNumber(regData.PhoneNumber)) {
                return RegistrationStatus.InvalidPhoneNumber;
            }
            
            if (!_validatePassword(regData.Password)) {
                return RegistrationStatus.TooWeakPassword;
            }

            if (regData.Password != regData.ConfirmPassword) {
                return RegistrationStatus.PasswordsDoNotMatch;
            }
            
            var user = new IndividualEntity {
                Name = regData.Name,
                Surname = regData.Surname,
                Email = regData.Email,
                PhoneNumber = regData.PhoneNumber
            };
            
            var salt = _generateSalt();
            user.Salt = salt;
            
            var checksum = _generateSHA256Checksum(regData.Password + salt);
            user.PasswordHash = checksum;

            return RegistrationStatus.Success;
        }

        public RegistrationStatus RegisterLegal(LegalEntityRegistrationData regData) {
            if (_userService.Exists(regData.Email)) {
                return RegistrationStatus.UserAlreadyExists;
            }

            if (!_validateEmail(regData.Email)) {
                return RegistrationStatus.InvalidEmail;
            }
            
            if (!_validatePassword(regData.Password)) {
                return RegistrationStatus.TooWeakPassword;
            }

            if (regData.Password != regData.ConfirmPassword) {
                return RegistrationStatus.PasswordsDoNotMatch;
            }
            
            var user = new LegalEntity {
                INN = regData.INN,
                KPP = regData.KPP,
                PhysicalAddress = regData.PhysicalAddress,
                LegalAddress = regData.LegalAddress,
                IsVerified = false
            };
            
            var salt = _generateSalt();
            user.Salt = salt;
            
            var checksum = _generateSHA256Checksum(regData.Password + salt);
            user.PasswordHash = checksum;

            return RegistrationStatus.Success;
        }
        
        private string _generateSHA256Checksum(string input) {
            var crypt = new SHA256Managed();
            var hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }

        private string _generateSalt() {
            return Guid.NewGuid().ToString("N");
        }

        private bool _validatePhoneNumber(string phoneNumber) {
            if (phoneNumber[0] == '+') {
                phoneNumber = phoneNumber.Substring(1);
            }
            
            return int.TryParse(phoneNumber, out _);
        }
        
        private bool _validatePassword(string password) {

            Regex[] validations = new[] {
                new Regex(@"[0-9]+"),
                new Regex(@"[A-Z]+"),
                new Regex(@".{8,}"),
            };

            foreach (var validation in validations) {
                if (!validation.IsMatch(password)) {
                    return false;
                }
            }
            
            return true;
            
        }

        private bool _validateEmail(string email) {
            return email.Contains("@");
        }

    }
}