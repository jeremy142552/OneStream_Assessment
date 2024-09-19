namespace OneStream_Assessment_Services.FrontEndService
{
    public interface IFrontEndService
    {
        Task<string> CallApi1();
        Task<string> CallApi2();
        Task<string> PostToApi1(object data);
        Task<string> PostToApi2(object data);
    }
}