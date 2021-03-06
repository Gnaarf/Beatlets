/// <summary>
/// Provides information on the current bar, and what note we're on.
/// </summary>
public class BeatInfo
{
    /// <summary>zero indexed</summary>
    public readonly int CurrentBar;
    /// <summary>zero indexed</summary>
    public readonly int SixtyfourthNoteInBar;
    /// <summary>zero indexed</summary>
    int ThirtysecondNoteInBar => SixtyfourthNoteInBar / 2;
    /// <summary>zero indexed</summary>
    int SixteenthNoteInBar => SixtyfourthNoteInBar / 4;
    /// <summary>zero indexed</summary>
    int EighthNoteInBar => SixtyfourthNoteInBar / 8;
    /// <summary>zero indexed</summary>
    int QuarterNoteInThisBar => SixtyfourthNoteInBar / 16;

    /// <summary>needs to have zero indexed parameters provided</summary>
    public BeatInfo(int currentBar, int sixtyfourthNoteInBar)
    {
        CurrentBar = currentBar;
        SixtyfourthNoteInBar = sixtyfourthNoteInBar;
    }
}