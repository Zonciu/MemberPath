namespace MemberPath
{
    internal enum PathCharState
    {
        Begin,

        MemberName,

        // .
        Dot,

        // [
        LeftBracket,

        // ]
        RightBracket,

        // string key char
        StringKey,

        // number key char
        NumberKey,

        // '
        SingleQuote,
    }
}
