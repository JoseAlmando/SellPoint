using AutoMapper;

namespace SellPoint.Utils
{
    public static partial class ExtensionsMethods
    {
        public static TDestino Map<TOrigen, TDestino>(this TOrigen elemento)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TOrigen, TDestino>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<TOrigen, TDestino>(elemento);

        }
    }
}