USE master
GO

--1.������ݿ�������汾
--����SQL Server 2005�����ϰ汾���ݿ��֧��ServiceBroker����
select @@version
GO

/*2.Ϊ���ݿ⿪��ServiceBroker����

�뽫DbnameXxx�޸�Ϊ�������ݿ���������

--ִ�й������п��ܳ���һЩ���⣬��ο����¹����Ų鷽����
--1.�����ݿⱻ��ʱ�����
--ִ��exec sp_who2 ���������Ľ��̺ţ�Ȼ��kill <spid>

�����κ����⣬����ϵ����Ң��4848285@qq.com����
*/
ALTER DATABASE [DbnameXxx] SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE;
GO

--3.������ݿ��Ƿ�ɹ�����ServiceBroker����
SELECT name, is_broker_enabled FROM sys.databases 
WHERE name='DbnameXxx'
-- ORDER BY name
GO

