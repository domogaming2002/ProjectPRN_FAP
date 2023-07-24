using Microsoft.EntityFrameworkCore;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.Bussiness.IRepository
{
    public interface IDetailScoreRepository
    {
         List<DetailScoreDTO>? GetList();

        DetailScoreDTO? GetById(int detailScoreId);

         Boolean Create(DetailScoreDTO detailScore);

         Boolean Delelte(DetailScoreDTO detailScore);
         Boolean Update(DetailScoreDTO detailScore);
    }
}
