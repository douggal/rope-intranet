namespace rope_intranet
{
    /// <summary>
    /// A representation a wire stretched between two buildings, A and B.
    /// </summary>
    public class Wire
    {
        public int A { get; set; }
        public int B { get; set; }
        public Wire(int a, int b)
        {
            A = a;
            B = b;
        }
    }
}
