namespace MemoryGame.Model.States
{
    public enum TileStates
    {
        Hidden,
        Preview,
        Found
    }

    public enum BoardStates
    {
        NoPreview,
        OnePreview,
        TwoPreview,
        TwoFound,
        TwoHiding,
        Finished
    }
}
