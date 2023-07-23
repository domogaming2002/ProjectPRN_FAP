using Microsoft.EntityFrameworkCore;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Models;

namespace ProjectPRN_FAP.Bussiness.IRepository
{
    public interface IStudentClassSubjectRepository
    {
        List<StudentClassSubjectDTO>? GetList();

        StudentClassSubjectDTO? GetById(int studentClassSubjectId);

        StudentClassSubjectDTO? GetByStudentIdClassSubjectId(int studentId, int classSubjectId);
        List<StudentClassSubjectDTO>? GetListByStudentId(int studentId);

        List<StudentClassSubjectDTO>? GetListByClassSubjectId(int classSubjectId);

        Boolean Create(StudentClassSubjectDTO studentClassSubject);

        Boolean Delelte(StudentClassSubjectDTO studentClassSubject);
        Boolean Update(StudentClassSubjectDTO studentClassSubject);
    }
}
