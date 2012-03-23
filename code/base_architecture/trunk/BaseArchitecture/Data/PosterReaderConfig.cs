namespace Data
{
    public interface IPosterReaderConfig
    {
        bool ReadsAs();
    }

    public class PosterAReader : IPosterReaderConfig
    {
        public bool ReadsAs()
        {
            return true;
        }
    }

    public class PosterBReader : IPosterReaderConfig
    {
        public bool ReadsAs()
        {
            return false;
        }
    }
}