using Microsoft.EntityFrameworkCore;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.Bussiness.IRepository
{
    public interface IClassSubjectRepository
    {
        List<ClassSubjectDTO> GetList();

        ClassSubjectDTO? GetById(int classSubjectId);
        ClassSubjectDTO? GetByAllId(int classId, int subjectId, int semesterId);
        List<ClassSubjectDTO>? GetListBySemester(int semesterId);
        List<ClassSubjectDTO>? GetListByTeacher(int teacherId);
        Boolean Create(ClassSubjectDTO classSubjectDTO);

        Boolean Delelte(ClassSubjectDTO classSubjectDTO);

        Boolean Update(ClassSubjectDTO classSubjectDTO);
    }
}
