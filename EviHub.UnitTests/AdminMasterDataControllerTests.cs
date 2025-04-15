using EviHub.Controllers;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Moq;
using Xunit;

namespace EviHub.UnitTests
{
    public class AdminMasterDataControllerTests
    {
        private readonly Mock<ISkillService> _skillServiceMock;
        private readonly AdminMasterDataController adminMasterDataController;
        public AdminMasterDataControllerTests()
        {
            _skillServiceMock = new Mock<ISkillService>();
            adminMasterDataController = new AdminMasterDataController(_skillServiceMock.Object);
        }
        [Fact]
        public void TestGetAllSkills()
        {
            //Arrange
            _skillServiceMock.Setup(x => x.GetAllSkillsAsync()).ReturnsAsync([]);

            //Act
            var result = adminMasterDataController.GetAllSkills();

            //Assert
            Assert.IsType(typeof(OkObjectResult), result);
        }

    }
}
