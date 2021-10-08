namespace Shared.Models.Chapter01
{
    public class Performance
    {
        public Play Play { get; set; }
        public int Audience { get; set; }

        public Performance(Play play, int audience)
        {
            Play = play;
            Audience = audience;
        }
    }
}
