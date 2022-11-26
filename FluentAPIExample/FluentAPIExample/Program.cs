using System;

namespace FluentAPIExample
{
    class Program
    {
        /*
         * Creating our own FluentAPI
         * Projeninin amacı:
         * Kullandığımız kütüphanelerde bizleri yönlendirdiklerini görüyoruz. 
         * Örneğin Db ye connect olmak istiyoruz ve server, db name, username, password ve connect methoduna ihtiyacımız var.
         * Normal şekilde hazırlanan bir class ta Server(), Db(),Username()...vs aldığımız methodlar alt alta listelenir ve 
         * belirli bir kural olmadan kullanabiliriz.
         * Ancak biz Server() methodu kullanılmadan Db() methodu kullanılamasın Db() methodu kullanılmadan  Username() methodu kullanılamasın istiyorsak
         * bu örnekteki yaklaşımı uygulayabiliriz.
         */
        static void Main(string[] args)
        {
            /*
             * Lamda tarzı kullanım aşağıdaki gibi
             */
            FluentSqlConnection.CreateConnection(config =>
            {
                config.ConnectionName = "connectionName";
            });

            /*
             * CreateConnection() ı çağırdıktan sonra . ya bastığımızda sadece ForServer() çıkıyor. 
             * ForServer() ı çağırdıktan sonra . ya bastığımızda sadece ForDatabase() çıkıyor.
             * ForDatabase() i çağırdıktan sonra . ya bastığımzda sadece AsUser() çıkıyor.
             * vs vs...
            */
            var connection = FluentSqlConnection.CreateConnection()
                        .ForServer("localhost")
                        .ForDatabase("sampleDb")
                        .AsUser("gunesbro")
                        .WithPassword("password")
                        .Connect();
        }
    }
}
