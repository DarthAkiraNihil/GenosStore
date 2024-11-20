namespace GenosStore.Utility.Types.Filtering {
    public class RangeItem {
        public int From { get; set; }
        public int To { get; set; }

        public RangeItem() {
            From = 0;
            To = 0;
        }
    }
}