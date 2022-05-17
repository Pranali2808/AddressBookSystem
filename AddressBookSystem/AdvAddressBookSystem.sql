---//UC1:-Create AddressBook Service Database---------------------
create database AddressBookService;
use AddressBookService;
---//UC2:-Create Address book table------------------------------
create table AddressBook(
FirstName varchar(100),
LastName varchar(100),
Address varchar(100),
City varchar(100),
State varchar (100),
Zip bigint,
PhoneNumber bigint,
Email varchar(100)
);
select * from AddressBook--//display the table//--
---//UC3:-Insert New Contact to AddressBook-----------
insert into AddressBook(FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email)
values('Akash','Patil','Niphad','Nashik','Maharashtra',465789,9859837990,'akash@gmail.com'),
('Pranali','Rane','Bhusawal','Jalgaon','Maharashtra',425305,9184854598,'pranalirane@gmail.com'),
('Vijay','Kale','Fekari','Jalgaon','Maharashtra',432064,9922096553,'vijaykale@gmail.com'),
('Kanchan','Patel','Sane Chowk','Pune','Maharashtra',468456,9894561814,'kanchanpatel@gmail.com');
select * from AddressBook;
---//UC4:-Edit existing Contact Using name------------------------------
update AddressBook set PhoneNumber=9130679234 where FirstName='Kanchan';
select * from AddressBook;
---//UC5:-Delete a person using name---------------------
insert into AddressBook(FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email)
values('Ajay','Pagare','Ambad','Nagpur','Maharastra',682322,9544727181,'ajaypagare@gmail.com');
select * from AddressBook;
delete AddressBook where FirstName='Ajay';

select * from AddressBook;
---//UC6:-Retriew a person by city or state---------------------
select * from AddressBook where City = 'Jalgaon' or State = 'Maharashtra';
----//UC7:-Abilty to understand size of addressbook  by city or state--------------
select COUNT(*) as StateCount, State from AddressBook group by State;
select COUNT(*) as CityCount, City from AddressBook group by City; 
---//UC8:-Retriew entriessorted alphabetically by person name--------------
select * from AddressBook order by FirstName;
---//UC9:-Identify each addressbook by its name and type-------------
alter table Addressbook add ContactType varchar(100) not null default 'Friend';
update AddressBook set ContactType = 'Family' where FirstName = 'Vijay';
select * from AddressBook;
---//UC10:-ability to get no of contact person by type-------------
select COUNT(*) as Type, ContactType from AddressBook group by ContactType;
---//UC11:-ability to add person both friend and family------
insert into AddressBook(FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email,ContactType)
values('Amol','Firake','Nehru Chowk','Jamner','Maharashtra',472067,8765432990,'amol@gmail.com','Friend'),
('Amol','Firake','Nehru Chowk','Jamner','Maharashtra',472067,8765432990,'amol@gmail.com','Family');

select * from AddressBook;
