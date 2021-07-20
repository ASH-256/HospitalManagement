--Create Database HospitalRecords
--GO
Create Table PatientsRecords
(
P_ID int IDENTITY(1,1) PRIMARY KEY,
PatientName varchar(150),
Address varchar(300),
ContactNumber bigint,
Age int,
Gender varchar(50),
BloodGroup varchar(50),
MajorDisease varchar(50),
S_ID bigint unique

)
GO
create table PatientsDiagnosisInformation(
S_ID bigint,
Symptoms varchar(150),
Diagnosis varchar(150),
Medicines varchar(150),
Ward varchar(15),
WardType varchar(30),

)
GO