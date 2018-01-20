using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using CRUDB_Utility.Data;
using CRUDB_Utility.Domain;
using DisconnectedGenericRepository;
using System.Data.Entity;
using System.Linq;
using System.Diagnostics;

namespace CRUDB_Utility.Test.Data
{
    [TestClass]
    public class GenericRepositotyTests
    {
        private StringBuilder _logBuilder = new StringBuilder();
        private string _log;
        private CRUModelContext _context;
        private GenericRepository<DataStructureType> _dataStructureDataTypeRepository;
        private GenericRepository<DataStructure> _dataStructureDataStructureRepository;

        public GenericRepositotyTests()
        {
            Database.SetInitializer(new NullDatabaseInitializer<CRUModelContext>());
            _context = new CRUModelContext();
            _dataStructureDataTypeRepository = new GenericRepository<DataStructureType>(_context);
            _dataStructureDataStructureRepository = new GenericRepository<DataStructure>(_context);
            SetupLogging();
        }

        [TestMethod]
        public void CanFindByDataStructureTypeByKeyWithDynamicLambda()
        {
            var results = _dataStructureDataTypeRepository.FindByKey(1);
            WriteLog();
            Assert.IsTrue(results.DataStructureTypeID == 1);
        }

        [TestMethod]
        public void CanFindByProductByKeyWithDynamicLambda()
        {
            var results = new GenericRepository<DataStructureType>(_context).FindByKey(1);
            WriteLog();
            Assert.IsTrue(_log.Contains("FROM [WHSE].[DataStructureType]"));
        }

        [TestMethod]
        public void CanIncludeNavigationProperties()
        {
            var results = _dataStructureDataStructureRepository.AllInclude(c => c.DataRules);
            WriteLog();
            Assert.IsTrue(_log.Contains("DataStructure"));
            Assert.IsTrue(results.Any(c => c.DataRules.Any()));
        }

        [TestMethod]
        public void ComposedOnAllListExecutedInMemory()
        {
            var results = _dataStructureDataTypeRepository.All().Where(c => c.DataStructureTypeID == 1).ToList();
            WriteLog();
            Assert.IsTrue(results.Count() == 1);
        }

        private void WriteLog()
        {
            Debug.WriteLine(_log);
        }

        private void SetupLogging()
        {
            _context.Database.Log = BuildLogString;
        }

        private void BuildLogString(string message)
        {
            _logBuilder.Append(message);
            _log = _logBuilder.ToString();
        }

    }
}
