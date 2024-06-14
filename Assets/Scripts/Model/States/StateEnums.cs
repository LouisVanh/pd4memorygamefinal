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
        WaitStart,
        NoPreview,
        OnePreview,
        TwoPreview,
        TwoFound,
        TwoHiding,
        Finished
    }
}
