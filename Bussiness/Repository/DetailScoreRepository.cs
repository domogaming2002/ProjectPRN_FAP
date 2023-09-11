using AutoMapper;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Manager;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.Bussiness.Repository
{
    public class DetailScoreRepository : IDetailScoreRepository
    {
        DetailScoreManager manager;
        DataContext _context;
        IMapper _mapper;

        public DetailScoreRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            manager = new DetailScoreManager(_context);
        }

        public bool Create(DetailScoreDTO detailScore)
        {
            if (GetById(detailScore.DetailScoreId) == null)
            {
                return manager.Create(_mapper.Map<DetailScore>(detailScore)); ;
            }
            else
            {
                return false;
            }
        }

        public bool Delelte(DetailScoreDTO detailScore)
        {

            if (GetById(detailScore.DetailScoreId) != null)
            {
                return manager.Delelte(_mapper.Map<DetailScore>(detailScore)); ;
            }
            else
            {
                return false;
            }
        }

        public DetailScoreDTO? GetById(int detailScoreId)
        {
            return _mapper.Map<DetailScoreDTO>(manager.GetById(detailScoreId));
        }

        public List<DetailScoreDTO>? GetByTranscriptId(int transcriptId)
        {
            return _mapper.Map<List<DetailScoreDTO>>(manager.GetByTranscriptId(transcriptId));
        }

        public List<DetailScoreDTO>? GetList()
        {
            return _mapper.Map<List<DetailScoreDTO>>(manager.GetList());
        }

        public bool Update(DetailScoreDTO detailScore)
        {

            if (GetById(detailScore.DetailScoreId) != null)
            {
                return manager.Update(_mapper.Map<DetailScore>(detailScore)); ;
            }
            else
            {
                return false;
            }
        }
    }
}
