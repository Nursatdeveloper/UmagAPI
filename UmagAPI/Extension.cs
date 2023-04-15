namespace UmagAPI {
    public static class Extension {
        public static bool InRange(this DateTime dateTime, DateTime minValue, DateTime maxValue) {
            if(dateTime.CompareTo(minValue) >= 0 && dateTime.CompareTo(maxValue) <= 0) {
                return true;
            }
            return false;

        }
    }
}
