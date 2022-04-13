namespace Framework.Domain.ValueObjects
{
    public class SeoData : ValueObject
    {
        private SeoData()
        {
        }

        public static SeoData CreateEmpty()
        {
            return new SeoData();
        }

        public SeoData(string metaKeyWords, string metaDescription, string metaTitle)
        {
            MetaKeyWords = metaKeyWords;
            MetaDescription = metaDescription;
            MetaTitle = metaTitle;
        }

        public string MetaTitle { get; private set; }
        public string MetaDescription { get; private set; }
        public string MetaKeyWords { get; private set; }
    }
}