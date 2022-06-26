namespace Contracts.DAL.Base.Mappers
{
    public interface IBaseMapper<TLeftObject, TRightObject>
    {
        /* Map from object A => object B
         or Object B => object A*/


        TLeftObject? Map(TRightObject? inObject);
        TRightObject? Map(TLeftObject? inObject);
    }
}