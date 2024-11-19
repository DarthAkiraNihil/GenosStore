namespace GenosStore.Utility.Types.AuthRegister {
    public enum RegistrationStatus {
        Success,
        UserAlreadyExists,
        TooWeakPassword,
        PasswordsDoNotMatch,
        InvalidPhoneNumber,
        InvalidEmail,
    }
}