namespace FPS.Infrastructure
{
    /// <summary>
    /// Probably don't even want this.  Thinking of having a (stack allocated?) array of
    /// named operations applied to a value (*2, -7, +5, etc.) so we can roll them back/
    /// see which ones are active.  Probably best to do this simply.
    /// </summary>
    public struct ValueChangeLog<T>
    {

    }
}

