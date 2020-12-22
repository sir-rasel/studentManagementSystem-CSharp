namespace StudentManagementSystem
{
    public static class ExtensionMethods
    {
        public static bool isDigitOnly(this string value)
        {
            foreach (char c in value)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        public static bool isAlphabetOnly(this string value)
        {
            foreach (char c in value)
            {
                if( !((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')) )
                {
                    return false;
                }
            }

            return true;
        }
    }
}
