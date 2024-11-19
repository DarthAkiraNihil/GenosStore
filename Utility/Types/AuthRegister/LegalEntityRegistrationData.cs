namespace GenosStore.Utility.Types.AuthRegister {
    public struct LegalEntityRegistrationData {
        public string Email { get; set; }
        public long INN { get; set; }
        public long KPP { get; set; }
        public string PhysicalAddress { get; set; }
        public string LegalAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}