namespace Romano
{
    public static partial class Romano
    {
        public static ushort Humanize(char roman, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            return Humanize(roman.ToString(), options);
        }
    }
}