using MetricsAgent;
using MetricsAgent.Controllers;
using System;
using Xunit;
using Moq;
using MetricsAgent.Repository;
using MetricsAgent.DAL.Models;

namespace Test
{
    public class UnitTests
    {
        private CpuMetricsController controller;
        private Mock<ICpuMetricsRepository> mock;
        private CpuPercentileMetricsController controller1;
        private Mock<ICpuPercentileMetricsRepository> mock1;
        private DotNetMetricsController controller2;
        private Mock<IDotNetMetricsRepository> mock2;
        private HddMetricsController controller3;
        private Mock<IHddMetricsRepository> mock3;
        private NetworkMetricsController controller4;
        private Mock<INetworkMetricsRepository> mock4;
        private RamMetricsController controller5;
        private Mock<IRamMetricsRepository> mock5;

        public UnitTests()
        {
            mock = new Mock<ICpuMetricsRepository>();
            mock1 = new Mock<ICpuPercentileMetricsRepository>();
            mock2 = new Mock<IDotNetMetricsRepository>();
            mock3 = new Mock<IHddMetricsRepository>();
            mock4 = new Mock<INetworkMetricsRepository>();
            mock5 = new Mock<IRamMetricsRepository>();

            controller = new CpuMetricsController(mock.Object);
            controller1 = new CpuPercentileMetricsController(mock1.Object);
            controller2 = new DotNetMetricsController(mock2.Object); 
            controller3 = new HddMetricsController(mock3.Object);
            controller4 = new NetworkMetricsController(mock4.Object);
            controller5 = new RamMetricsController(mock5.Object);
        }

        [Fact]
        public void CpuMetricsController_Test()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            mock.Setup(repository => repository.Create(It.IsAny<CpuMetric>())).Verifiable();

            // выполняем действие на контроллере
            var result = controller.Create(new MetricsAgent.CpuMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }
        [Fact]
        public void CpuPercentileMetricsController_Test()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            mock1.Setup(repository => repository.Create(It.IsAny<CpuPercentileMetrics>())).Verifiable();

            // выполняем действие на контроллере
            var result = controller1.Create(new MetricsAgent.Requests.CpuPercentileMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock1.Verify(repository => repository.Create(It.IsAny<CpuPercentileMetrics>()), Times.AtMostOnce());
        }
        [Fact]
        public void DotNetMetricsController_Test()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            mock2.Setup(repository => repository.Create(It.IsAny<DotNetMetrics>())).Verifiable();

            // выполняем действие на контроллере
            var result = controller2.Create(new MetricsAgent.Requests.DotNetMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock2.Verify(repository => repository.Create(It.IsAny<DotNetMetrics>()), Times.AtMostOnce());
        }
        [Fact]
        public void HddMetricsController_Test()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            mock3.Setup(repository => repository.Create(It.IsAny<HddMetrics>())).Verifiable();

            // выполняем действие на контроллере
            var result = controller3.Create(new MetricsAgent.Requests.HddMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock3.Verify(repository => repository.Create(It.IsAny<HddMetrics>()), Times.AtMostOnce());
        }
        [Fact]
        public void NetworkMetricsController_Test()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            mock4.Setup(repository => repository.Create(It.IsAny<NetworkMetrics>())).Verifiable();

            // выполняем действие на контроллере
            var result = controller4.Create(new MetricsAgent.Requests.NetworkMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock4.Verify(repository => repository.Create(It.IsAny<NetworkMetrics>()), Times.AtMostOnce());
        }
        [Fact]
        public void RamMetricsController_Test()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            mock5.Setup(repository => repository.Create(It.IsAny<RamMetrics>())).Verifiable();

            // выполняем действие на контроллере
            var result = controller5.Create(new MetricsAgent.Requests.RamMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock5.Verify(repository => repository.Create(It.IsAny<RamMetrics>()), Times.AtMostOnce());
        }
    }
}





