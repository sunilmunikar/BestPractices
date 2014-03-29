using AutoMapper;

namespace My.Framework.Infrastructure
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}
