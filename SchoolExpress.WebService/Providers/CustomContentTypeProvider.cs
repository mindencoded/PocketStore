using Microsoft.Owin.StaticFiles.ContentTypes;

namespace SchoolExpress.WebService.Providers
{
    public class CustomContentTypeProvider : FileExtensionContentTypeProvider
    {
        public CustomContentTypeProvider()
        {
            Mappings.Add(".json", "application/json");
        }
    }
}