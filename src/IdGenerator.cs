namespace RedeSocialW
{
    public static class IdGenerator
    {
        static int _id = 1;
        public static int Next() => _id++;
    }
}
