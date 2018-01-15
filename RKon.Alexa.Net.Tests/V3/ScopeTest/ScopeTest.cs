using Newtonsoft.Json;
using RKon.Alexa.Net.Tests.V3.TestFunctions;
using RKon.Alexa.NET.JsonObjects.Scopes;
using RKon.Alexa.NET.Types;
using Xunit;

namespace RKon.Alexa.Net.Tests.V3.ScopeTest
{
    public class ScopeTest
    {
        private const string BEARERTOKEN = @"{
        'type': 'BearerToken',
        'token': 'access-token-from-Amazon'
        }";

        private const string BEARERTOKEN_WITH_PARTITION = @"{
        'type': 'BearerTokenWithPartition',
        'token': 'some-access-token',
        'partition': 'Room101',
        'userId':'some-user-id'
        }";

        [Fact]
        public void BearerTokenDeserialization()
        {
            Scope scope = JsonConvert.DeserializeObject<Scope>(BEARERTOKEN);
            //Directive Check
            Assert.NotNull(scope);
            TestFunctionsV3.TestBearerTokenV3(scope, "access-token-from-Amazon");
        }

        [Fact]
        public void BearerTokenSerialization()
        {
            BearerToken constScope = JsonConvert.DeserializeObject<Scope>(BEARERTOKEN) as BearerToken;
            BearerToken scope = new BearerToken("access-token-from-Amazon");
            //Context check
            Assert.Equal(constScope.Type, scope.Type);
            Assert.Equal(constScope.Token, scope.Token);
        }

        [Fact]
        public void BearerTokenWithPartitionDeserialization()
        {
            Scope scope = JsonConvert.DeserializeObject<Scope>(BEARERTOKEN_WITH_PARTITION);
            //Directive Check
            Assert.NotNull(scope);
            TestFunctionsV3.TestBearerTokenWithPartitionV3(scope, "some-access-token", "Room101", "some-user-id");
        }

        [Fact]
        public void BearerTokenWithPartitionSerialization()
        {
            BearerTokenWithPartition constScope = JsonConvert.DeserializeObject<Scope>(BEARERTOKEN_WITH_PARTITION) as BearerTokenWithPartition;
            BearerTokenWithPartition scope = new BearerTokenWithPartition("some-access-token", "Room101", "some-user-id");
            //Context check
            Assert.Equal(constScope.Type, scope.Type);
            Assert.Equal(constScope.Token, scope.Token);
            Assert.Equal(constScope.UserId, scope.UserId);
            Assert.Equal(constScope.Partition, scope.Partition);
        }
    }
}
