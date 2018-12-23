using POC.Models;
using POC.Repository.Interface;
using System;
using System.Linq;
using System.Web.Http;
namespace POC.Controllers
{

    public class ProjectController : ApiController
    {
      
        private readonly IProjectRepository _IProjectRepository;
        private readonly ILogger _logger;
        public ProjectController(IProjectRepository IProjectRepository,ILogger logger)
        {         
            _IProjectRepository = IProjectRepository;
            _logger = logger;
        }

        /// <summary>
        /// Add Project
        /// </summary>
        /// <param name="ProjectMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Save(ProjectMaster ProjectMaster)
        {
            var result = _IProjectRepository.Save(ProjectMaster);
            return Ok(ProjectMaster);
        }

        /// <summary>
        /// Get List of Projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var projectdata = _IProjectRepository.GetAll("ProjectName", "Asc", "").ToList();
            return Ok(projectdata);
        }
        
        /// <summary>
        /// Get List of Projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetById(int ID)
        {
            var projectdata = _IProjectRepository.GetById(ID);
            return Ok(projectdata);
        }

        /// <summary>
        /// Delete project
        /// </summary>
        /// <param name="ID">Project Id</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Delete(string ID)
        {
            var data = _IProjectRepository.Delete(Convert.ToInt32(ID));
            if (data > 0)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        
    }
}