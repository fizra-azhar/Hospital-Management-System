create data/base project_HMS
use project_HMS
select * from departments


create table doctors
(
doctor_id int identity primary key ,
doctor_name varchar(50) unique,
doctor_gender varchar(50),
Sdoctor_contact bigint,
doctor_qualification nvarchar(50),
doctor_specialization nvarchar(50),
doctor_salary bigint,
department_id int foreign key references departments(department_id)
)

select * from doctors

insert into doctors values
('aqibb','male',12 , 0311, 'MBBS' , 'Heart Sergeon' , 250000,3),
('hafeez','male',48 , 0311, 'BDS' , 'Dentist' , 100000,2)


select * from departments


create table patients
(
patient_id int identity primary key ,
patient_name varchar(50),
patient_gender varchar(50),
patient_age int,
patient_contact bigint,
patient_weight int
)
insert into patients values
('Nabhiya','female',28 , 0311, 90),
('Tabassum','female',20 , 0311, 56)

create table appointments
(
appointment_id int identity primary key ,
patient_id int foreign key references patients(patient_id),
doctor_id int foreign key references doctors(doctor_id),
date_time datetime,
admin_id int,
disease nvarchar(50),
prescription nvarchar(50), 
)
insert into appointments values
(1,2,1,NULL, 'heart attack', 'inderal'),
(2,3,2,NULL, 'tooth cavity', 'panadol')

create table labs
(
lab_id int identity primary key ,
lab_name nvarchar(50),
lab_charges nvarchar(50),
staff_id int foreign key references staffs(staff_id)
)
insert into labs values
('cbc' , '2500' , 01),
('CT scan' , '4000', 01 )

create table expenses
(
exp_id int identity primary key ,
exp_name nvarchar(50),
exp_amount int,
date_time datetime,
)
insert into expenses values
('cleaning exp', 25000, CURRENT_TIMESTAMP),
('machinery exp', 125000, CURRENT_TIMESTAMP),
('furniture', 125000, CURRENT_TIMESTAMP),
('medical equipments', 125000, CURRENT_TIMESTAMP),
('food for  patients', 125000, CURRENT_TIMESTAMP)

create table doctors_payment
(
doctor_payment_id int identity primary key,
doctor_id int foreign key references doctors(doctor_id),
date_time datetime,
doctor_payment_amount bigint,
month_of_salary nvarchar(50),
)
 insert into doctors_payment values 
 (02, CURRENT_TIMESTAMP, 250000 , 'september'),
 (03, CURRENT_TIMESTAMP, 250000, 'june')
 
 
 create table staff_payments
 (
 staff_payment_id int identity primary key,
 staff_id int foreign key references staffs(staff_id),
 date_time datetime,
 staff_payment_amount bigint,
 month_of_salary nvarchar(50)
 )
 insert into staff_payments values 
 (01, CURRENT_TIMESTAMP, 2500 , 'september'),
 (02, CURRENT_TIMESTAMP, 2600, 'june')
 
 create table departments
 (
 department_id int identity primary key,
 department_name nvarchar(50)
 )
 insert into departments values
 ('accounts'),
 ('doctors assistancy'),
 ('arthopetic')
 
  create table room_types(
  room_type_id int identity primary key,
  room_type nvarchar(50)
  )
  insert into room_types values
   ('icu'),
   ('ventilator')
  
  create table rooms
  (
  room_id int identity primary key,
  no_of_beds nvarchar(50),
  room_type_id int foreign key references room_types(room_type_id)
  )
  insert into rooms values
  ('7' , 01),
  ('6' , 02)
  
  
  
  create table assigned_rooms
  (
  room_assigned_id int identity primary key,
  room_assigned_indate datetime,
  room_assigned_outdate datetime,
  patient_id int foreign key references patients(patient_id),
  doctor_id int foreign key references doctors(doctor_id),
  room_id int foreign key references rooms(room_id),
  staff_id int foreign key references staffs(staff_id) 
  )
  
  
  insert into assigned_rooms values 
  (CURRENT_TIMESTAMP, CURRENT_TIMESTAMP , 01 , 02 , 01 , 01),
  (CURRENT_TIMESTAMP, CURRENT_TIMESTAMP , 02 , 03 , 02 , 02)
  
  
  
  create table staffs
  (
  staff_id int identity primary key,
  staff_name nvarchar(50),
  staff_designation nvarchar(50),
  staff_gender nvarchar(50),
  staff_age int,
  staff_contact bigint,
  salary bigint,
  department_id int foreign key references departments(department_id) 
  )
  insert into staffs values
  ('alina shah ' , 'receptionist' , 'female' , 26 , 0323 , 10000, 01),
  ('hammad alvi ' , 'ward boy' , 'male' , 29 , 0323 , 8000, 02)
  
  alter table doctors 
  add constraint ck_doctors_doctor_age check (doctor_age > 40)
  
  alter table doctors 
  add constraint ck_doctors_doctor_contact check (doctor_contact > 999999999 )
  
  
select * from doctors
select * from patients
select * from appointments
select * from labs
select * from expenses
select * from doctors_payment
select * from staff_payments
select * from departments
select * from room_types
select * from rooms
select * from assigned_rooms
select * from staffs

 create proc sp1
 as
 begin
select * from doctors

 end
  create proc sp2
 as
 begin
select * from patients

 end
 
  create proc sp3
 as
 begin
select * from appointments

 end
 
 create proc sp4
 as
 begin
select * from labs

 end
 
  create proc sp5
 as
 begin
select * from expenses

 end
 
 exec sp5
  create proc sp6
 as
 begin
select * from doctors_payment

 end
 
  create proc sp7
 as
 begin
select * from staff_payments

 end
 
  create proc sp8
 as
 begin
select * from departments

 end
 
  create proc sp9
 as
 begin
select * from room_types

 end
 
  create proc sp10
 as
 begin
select * from assigned_rooms

 end

 create proc sp11
 as
 begin
select * from rooms

 end
 
  create proc spstaff
 as
 begin
select * from staffs

 end
 
 exec spstaff
 
 exec sp1
 select * from doctors
 
 create proc spInsertdoc
@doctor_name varchar(50),
@doctor_gender varchar(50),
@doctor_contact bigint,
@doctor_qualification nvarchar(50),
@doctor_specialization nvarchar(50),
@doctor_salary bigint,
@department_id int,
@doctor_age int
as
begin
insert into doctors(doctor_name,doctor_gender,doctor_contact,doctor_qualification,doctor_specialization,doctor_salary,department_id,doctor_age)
values(@doctor_name,@doctor_gender,@doctor_contact,@doctor_qualification,@doctor_specialization,@doctor_salary,@department_id,@doctor_age)
 end
 select * from departments
  create proc spdeldoc
@doctor_name varchar(50)
as
begin
set nocount on;
delete from doctors where doctor_name = @doctor_name
end
 
select * from doctors_payment
select * from doctors
select * from appointments


update doctors set doctor_id = 3 where doctor_id = 7

update doctors set doctor_name = 'Amin Raheed' where doctor_id =1
update doctors set doctor_name = 'Akram Babar' where doctor_id =2

select * from doctors where doctors 

SELECT * FROM doctors
WHERE doctor_name LIKE 'ak%';


after delete
as
declare 
@doctor_id int
 delete  from doctors where doctor_id = @doctor_id 
 begin
 delete from doctors_payment where doctor_id = @doctor_id
 end
 
 
create trigger whendocinsert
instead delete
as
declare 
@doctor_id int
begin
 delete  from doctors where doctor_id = @doctor_id 
 
 delete from doctors_payment where doctor_id = @doctor_id
 end
 
 
 create trigger whendocinsert
instead delete
as
declare 
@doctor_id int
begin
 delete  from doctors where doctor_id = @doctor_id 
 
 delete from doctors_payment where doctor_id = @doctor_id
 end
 
 --PATIENTS
 
 select * from patients
 
  create proc spInsertpat
@patient_name varchar(50),
@patient_gender varchar(50),
@patient_contact bigint,
@patient_age int,
@patient_weight int
as
begin
insert into patients(patient_name, patient_gender, patient_contact, patient_age, patient_weight)
values(@patient_name,@patient_gender, @patient_contact , @patient_age, @patient_weight)
 end
 
 
 ALTER TABLE patients
ALTER COLUMN patient_contact bigint;
 select * from patients
 
create trigger whenpatdel2 on [dbo].[patients]
 delete
as
declare 
@patient_id int
begin
 delete  from patients where patient_id = @patient_id
 
 delete from appointments where patient_id = @patient_id
 delete from assigned_rooms where patient_id = @patient_id
 end
 
 delete from patients where patient_id = 26
 select * from assigned_rooms
 select * from appointments
 select * from patients
 
 --staffs
 
 select * from staffs
 
 select * from departments
 
 
create proc spInserstaff
@staff_name nvarchar(50),
@staff_designation nvarchar(50),
@staff_gender nvarchar(50),
@staff_age int,
@staff_contact bigint,
@staff_salary bigint,
@department_id int
as
begin
insert into staffs(staff_name, staff_designation, staff_gender , staff_age , staff_contact, salary, department_id)
values(@staff_name , @staff_designation , @staff_gender , @staff_age , @staff_contact, @staff_salary , @department_id)
 end
 
 --staff
 
 create proc spInsertdep
@department_name nvarchar(50)
as
begin
insert into departments(department_name)
values(@department_name)
 end
 
 select * from departments
 
  --exp
 
 create proc spInsertexp
@exp_name nvarchar(50),
@exp_amount int,
@date_time datetime
as
begin
insert into expenses(exp_name, exp_amount , date_time)
values(@exp_name , @exp_amount , @date_time)
 end
 
 select * from departments
 delete from doctors where doctor_id = 22 and ( doctor_name = 'fiizra')
 
 select * from doctors
 
 Alter proc spInsertdept
@dep_name nvarchar(50),
@dep_room int,
@dep_emp int
as
begin
 try
insert into departments(department_name, Rooms , Employees)
values(@dep_name , @dep_room , @dep_emp)
 end try 
 begin catch
 
select 'enter some wrong values'
 end catch
 
 
 select * from departments
 
  
begin
set nocount on;
delete from doctors where doctor_name = @doctor_name
end 
try
	BEGIN CATCH
		INSERT INTO project_HMS
		VALUES
	(
	 ERROR_MESSAGE())
	 
	 
	 
	 
	 
	 
 
	 DECLARE @Message varchar(MAX) = ERROR_MESSAGE()
 
	 RAISEERROR (@Message)
	END CATCH
	end
	
	
 
 