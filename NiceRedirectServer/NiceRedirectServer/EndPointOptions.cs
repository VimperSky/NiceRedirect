namespace NiceRedirectServer
{
    public class EndPointOptions
    {
        public const string Name = "EndPoints";
        
        public string FrontEndAddress { get; init; }
        
        public string NotFoundAddress { get; init; }
        
        public string FormWithPasswordAddress { get; init; }
    }
}