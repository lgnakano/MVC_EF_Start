using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
  public class DatabaseExampleController : Controller
  {
    public ApplicationDbContext dbContext;

    public DatabaseExampleController(ApplicationDbContext context)
    {
      dbContext = context;
    }

    public IActionResult Index()
    {
      return View();
    }

    public async Task<ViewResult> DatabaseOperations()
    {
/*      // CREATE operation
      Company MyCompany = new Company();
      MyCompany.symbol = "MCOB";
      MyCompany.name = "ISM";
      MyCompany.date = "ISM";
      MyCompany.isEnabled = true;
      MyCompany.type = "ISM";
      MyCompany.iexId = "ISM";

      Quote MyCompanyQuote1 = new Quote();
      //MyCompanyQuote1.EquityId = 123;
      MyCompanyQuote1.date = "11-23-2018";
      MyCompanyQuote1.open = 46.13F;
      MyCompanyQuote1.high = 47.18F;
      MyCompanyQuote1.low = 44.67F;
      MyCompanyQuote1.close = 47.01F;
      MyCompanyQuote1.volume = 37654000;
      MyCompanyQuote1.unadjustedVolume = 37654000;
      MyCompanyQuote1.change = 1.43F;
      MyCompanyQuote1.changePercent = 0.03F;
      MyCompanyQuote1.vwap = 9.76F;
      MyCompanyQuote1.label = "Nov 23";
      MyCompanyQuote1.changeOverTime = 0.56F;
      MyCompanyQuote1.symbol = "MCOB";

      Quote MyCompanyQuote2 = new Quote();
      //MyCompanyQuote1.EquityId = 123;
      MyCompanyQuote2.date = "11-23-2018";
      MyCompanyQuote2.open = 46.13F;
      MyCompanyQuote2.high = 47.18F;
      MyCompanyQuote2.low = 44.67F;
      MyCompanyQuote2.close = 47.01F;
      MyCompanyQuote2.volume = 37654000;
      MyCompanyQuote2.unadjustedVolume = 37654000;
      MyCompanyQuote2.change = 1.43F;
      MyCompanyQuote2.changePercent = 0.03F;
      MyCompanyQuote2.vwap = 9.76F;
      MyCompanyQuote2.label = "Nov 23";
      MyCompanyQuote2.changeOverTime = 0.56F;
      MyCompanyQuote2.symbol = "MCOB";

      dbContext.Companies.Add(MyCompany);
      dbContext.Quotes.Add(MyCompanyQuote1);
      dbContext.Quotes.Add(MyCompanyQuote2);

      dbContext.SaveChanges();
      
      // READ operation
      Company CompanyRead1 = dbContext.Companies
                              .Where(c => c.symbol == "MCOB")
                              .First();

      Company CompanyRead2 = dbContext.Companies
                              .Include(c => c.Quotes)
                              .Where(c => c.symbol == "MCOB")
                              .First();

      // UPDATE operation
      CompanyRead1.iexId = "MCOB";
      dbContext.Companies.Update(CompanyRead1);
      //dbContext.SaveChanges();
      await dbContext.SaveChangesAsync();*/

            // DELETE operation
            //dbContext.Companies.Remove(CompanyRead1);
            //await dbContext.SaveChangesAsync();

            Student student1 = new Student();
            student1.Name = "Bob";
            dbContext.Students.Add(student1);

            Student student2 = new Student();
            student2.Name = "Alice";
            dbContext.Students.Add(student2);

            dbContext.SaveChanges();

            Course course = new Course();
            course.Name = "ISM6255";
            dbContext.Courses.Add(course);

            dbContext.SaveChanges();

            Enrolment enrolment1 = new Enrolment();
            enrolment1.course = course;
            enrolment1.student = student1;
            enrolment1.grade = "A";
            dbContext.Enrolments.Add(enrolment1);

            Enrolment enrolment2 = new Enrolment();
            enrolment2.course = course;
            enrolment2.student = student2;
            enrolment2.grade = "A+";
            dbContext.Enrolments.Add(enrolment2);

            await dbContext.SaveChangesAsync();


      return View(student1);
    }

    public ViewResult LINQOperations()
    {
            ReturnValueLINQOperations retVal = new ReturnValueLINQOperations();
      Company CompanyRead1 = dbContext.Companies
                                      .Where(c => c.symbol == "MCOB")
                                      .First();
            retVal.company1 = CompanyRead1;
      Company CompanyRead2 = dbContext.Companies
                                      .Include(c => c.Quotes)
                                      .Where(c => c.symbol == "MCOB")
                                      .First();
            retVal.company2 = CompanyRead2;
      Quote Quote1 = dbContext.Companies
                              .Include(c => c.Quotes)
                              .Where(c => c.symbol == "MCOB")
                              .FirstOrDefault()
                              .Quotes
                              .FirstOrDefault();
            retVal.quote1 = Quote1;
      return View(retVal);
    }

    public ViewResult LINQManyToMany()
    {
            Student student = dbContext.Students
                                .Where(c => c.Name == "Bob")
                                .First();
            Enrolment enrolment = dbContext.Enrolments
                                .Include(e => e.course)
                                .Where(e => e.student == student)
                                .First();
            Course course = dbContext.Courses
                            .Where(c => c.Id == enrolment.course.Id)
                            .First();
            StudentCourseEnrolment sce = new StudentCourseEnrolment();
            sce.course = course;
            sce.student = student;
            sce.enrolment = enrolment;
       return View(sce);
    }

  }
}