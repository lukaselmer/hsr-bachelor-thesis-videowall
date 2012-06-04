namespace VideoWall.ServiceModels.HandCursor
{
    /// <summary>
    ///   The delegate for when the hand is changed (left or right hand)
    /// </summary>
    /// <param name="handType"> Type of the hand. </param>
    public delegate void HandChanged(HandType handType);
}