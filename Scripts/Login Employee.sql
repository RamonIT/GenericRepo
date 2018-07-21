Create database Enterprise

use Enterprise

create table Employee
(
CodEmployee int identity(1,1),
Name Varchar(300)
)

select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'SystemUsers'

alter table Employee 
add constraint PK_Employee primary key (CodEmployee)

create table SystemUsers
(
CodUser int identity(1,1) primary key not null,
CodEmployee int foreign key References Employee(CodEmployee),
Username varchar(10) not null,
TxtPassword varchar(10) not null
)

exec sp_rename'SystemUsers.NumPassword', 'TxtPassword', 'COLUMN'

insert into Employee (Name)
values ('Ramon Santos de Resende')


insert into SystemUsers (CodEmployee, Username, TxtPassword)
values (1, 'rsresende', 'linklink')

select * from Employee

select * from SystemUsers

--drop database enterprise

--drop table Employee