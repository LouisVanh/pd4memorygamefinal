namespace MemoryGame.Data
{
    public class DBImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsBack { get; set; }
        public byte[] Image { get; set; }
    }
}