namespace Romano
{
    public static partial class Romano
    {
        public static string Romanize(byte number, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            return Romanize((ushort)number, options);
        }
        
        public static string Romanize(sbyte number, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            return Romanize((ushort)number, options);
        }
        
        public static string Romanize(short number, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            return Romanize((ushort)number, options);
        }
        
        public static string Romanize(int number, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            return Romanize((ushort)number, options);
        }
        
        public static string Romanize(uint number, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            return Romanize((ushort)number, options);
        }
        
        public static string Romanize(long number, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            return Romanize((ushort)number, options);
        }
        
        public static string Romanize(ulong number, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            return Romanize((ushort)number, options);
        }
        
        public static string Romanize(float number, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            return Romanize((ushort)number, options);
        }
        
        public static string Romanize(double number, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            return Romanize((ushort)number, options);
        }
        
        public static string Romanize(decimal number, RomanizerOptions options = RomanizerOptions.DEFAULT_STRICT)
        {
            return Romanize((ushort)number, options);
        }
    }
}