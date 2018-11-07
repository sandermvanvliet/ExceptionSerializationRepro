using System;
using System.Linq;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace tests
{
    public class WhenSerializingExceptions
    {
        [Fact]
        public void GivenAssemblyWithCompilationRelaxations_SerializedExceptionDoesNotContainTargetSite()
        {
            Exception caughtException = null;

            try
            {
                new ClassLibWithCompilationRelaxations.Class1().BlowUp();
            }
            catch (Exception ex)
            {
                caughtException = ex;
            }

            var serialized = JsonConvert.SerializeObject(
                caughtException, 
                Formatting.None,
                new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});

            var jsonObject = JsonConvert.DeserializeObject(serialized) as JObject;

            var targetSiteProperty = jsonObject
                .Properties()
                .Select(p => p.Name)
                .SingleOrDefault(p => p == "TargetSite");

            targetSiteProperty.Should().BeNull();
        }

        [Fact]
        public void GivenAssemblyWithoutCompilationRelaxations_SerializedExceptionDoesNotContainTargetSite()
        {
            Exception caughtException = null;

            try
            {
                new ClassLibWithoutCompilationRelaxations.Class1().BlowUp();
            }
            catch (Exception ex)
            {
                caughtException = ex;
            }

            var serialized = JsonConvert.SerializeObject(
                caughtException, 
                Formatting.None,
                new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});

            var jsonObject = JsonConvert.DeserializeObject(serialized) as JObject;

            var targetSiteProperty = jsonObject
                .Properties()
                .Select(p => p.Name)
                .SingleOrDefault(p => p == "TargetSite");

            targetSiteProperty.Should().BeNull();
        }
    }
}
