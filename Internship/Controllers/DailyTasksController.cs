using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.ModelRepresentation;
using Internship.ModelView;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Internship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyTasksController : ControllerBase
    {
        // GET: api/DailyTasks
        [HttpGet]
        public List<DailyTaskView> Get()
        {
            List<DailyTaskView> dailyTaskList = new List<DailyTaskView>();

            using (DailyTaskDBContext db = new DailyTaskDBContext())
            {
                var result = db.DailyTaskTable;
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        DailyTaskView dailyTaskView = new DailyTaskView();
                        dailyTaskView.DailyTaskID = item.DailyTaskID;
                        dailyTaskView.IsCompleted = item.IsCompleted;
                        dailyTaskView.TaskDescription = item.TaskDescription;
                        dailyTaskView.TaskDueDate = item.TaskDueDate;
                        dailyTaskView.TaskName = item.TaskName;

                        dailyTaskList.Add(dailyTaskView);
                    }
                }
            }

            return dailyTaskList;
        }

        // GET api/<DailyTasks/5
        [HttpGet("{id}")]
        public DailyTaskView Get(int id)
        {

            if (id > 0)
            {
                using (DailyTaskDBContext db = new DailyTaskDBContext())
                {
                    var result = db.DailyTaskTable.FirstOrDefault(p => p.DailyTaskID == id);
                    if (result != null)
                    {
                        DailyTaskView dailyTaskView = new DailyTaskView();
                        dailyTaskView.DailyTaskID = result.DailyTaskID;
                        dailyTaskView.IsCompleted = result.IsCompleted;
                        dailyTaskView.TaskDescription = result.TaskDescription;
                        dailyTaskView.TaskDueDate = result.TaskDueDate;
                        dailyTaskView.TaskName = result.TaskName;

                        return dailyTaskView;
                    }
                }
            }
            return null;
        }

        // POST api/DailyTasks
        [HttpPost]
        public void Post([FromBody] DailyTaskView dailyTask)
        {
            if (dailyTask != null)
            {
                using (DailyTaskDBContext db = new DailyTaskDBContext())
                {
                    DailyTaskRepresentation dailyTaskRepresentation = new DailyTaskRepresentation();
                    dailyTaskRepresentation.IsCompleted = dailyTask.IsCompleted;
                    dailyTaskRepresentation.TaskDescription = dailyTask.TaskDescription;
                    dailyTaskRepresentation.TaskDueDate = dailyTask.TaskDueDate;
                    dailyTaskRepresentation.TaskName = dailyTask.TaskName;

                    db.DailyTaskTable.Add(dailyTaskRepresentation);
                    db.SaveChanges();
                }
            }
        }

        // PUT api/DailyTasks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DailyTaskView dailyTask)
        {
            if (dailyTask != null)
            {
                using (DailyTaskDBContext db = new DailyTaskDBContext())
                {
                    DailyTaskRepresentation dailyTaskRepresentation = new DailyTaskRepresentation();
                    dailyTaskRepresentation.IsCompleted = dailyTask.IsCompleted;
                    dailyTaskRepresentation.TaskDescription = dailyTask.TaskDescription;
                    dailyTaskRepresentation.TaskDueDate = dailyTask.TaskDueDate;
                    dailyTaskRepresentation.TaskName = dailyTask.TaskName;

                    db.DailyTaskTable.Update(dailyTaskRepresentation);
                    db.SaveChanges();

                }
            }
        }

        // DELETE api/DailyTasks/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id > 0)
            {
                using (DailyTaskDBContext db = new DailyTaskDBContext())
                {
                    var result = db.DailyTaskTable.FirstOrDefault(p => p.DailyTaskID == id);
                    if(result != null)
                    {
                        db.DailyTaskTable.Remove(result);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
