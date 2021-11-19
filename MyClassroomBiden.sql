/*
	**** 12-10-2021 ****
    - Thêm proc điểm danh học sinh cho giáo viên (`sp_ins_updAttendance_hs`)
    - Thêm proc điểm danh sinh viên cho giáo viên (`sp_ins_updAttendance_uni`)
    - Thêm proc để tạo khung nhìn điểm danh học sinh cho giáo viên (`sp_viewAttendance_hs`)
    - Thêm proc để tạo khung nhìn điểm danh học sinh cho giáo viên (`sp_viewAttendance_uni`)
	**** 03-10-2021 ****
    - Thêm proc thêm học sinh vào lớp theo môn ở phổ thông cho admin (`sp_insertStudInClassBySub_hs`)
    - Thêm proc thêm học sinh vào lớp theo môn ở đại học cho admin (`sp_insertStudInClassBySub_uni`)
    - Thêm proc xoá học sinh ở lớp theo môn ở phổ thông cho admin (`sp_deleteStudInClassBySub_hs`)
	- Thêm proc xoá học sinh ở lớp theo môn ở đại học cho admin (`sp_deleteStudInClassBySub_uni`)
    - Thêm proc thêm buổi học cho lớp theo môn cho giáo viên (`sp_ins_updStudy`)
    - Thêm proc xoá buổi học cho lớp theo môn cho giáo viên (`sp_deleteStudy`)
    **** 23-09-2021 ****
    - Thêm proc thêm và sửa môn học cho admin (sp_ins_updSubject)
    - Thêm proc xoá môn học cho admin (sp_deleteSubject)
    - Thêm proc thêm và sửa lớp theo môn (sp_ins_updClass_by_Sub)
    - Thêm proc xoá lớp theo môn (sp_deleteClass_by_Sub)
    - Thêm proc cập nhật học sinh sinh viên (sp_updateStudent)
    - Thêm proc xoá học sinh sinh viên (sp_deleteStudent)
	**** 21-09-2021 ****
    - Thêm proc thêm học sinh cho admin (sp_insertStudent)
	**** OLD **** 
    - Thêm cột Tchr_inSChool ở bảng Teacher_Info để nhận biết giáo viên đó còn làm tại trường hay k, xem thêm cmt ở tại vị trí đó
	- Thêm PROC sp_updateRole_Work để thay đổi Role và tình trạng công tác của giáo viên đó, này là cho admin dùng
	- Thêm PROC sp_insertFaculty để thêm một khoa mới vào trường đại học
    - Thêm PROC sp_insertSpeciality để thêm một chuyên ngành mới vào khoa đã có
    - Thêm PROC sp_insertClass_UNI để thêm một lớp mới vào chuyên ngành và khoa đã có
    - Thêm PROC sp_insertClass_HS để thêm một lớp mới vào trường học phổ thông
*/


Create schema myclassroombiden;
Use myclassroombiden;
ALTER DATABASE myclassroombiden CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng FACULTY (Khoa)
CREATE TABLE IF NOT EXISTS `FACULTY` (
    FCT_ID VARCHAR(15),
    FCT_Name NVARCHAR(30) NOT NULL ,
    PRIMARY KEY (FCT_ID)
);
ALTER TABLE FACULTY CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng SPECIALITY (Chuyên ngành)
CREATE TABLE IF NOT EXISTS `SPECIALITY` (
    SPC_ID VARCHAR(15),
    SPC_Name NVARCHAR(30) NOT NULL,
    SPC_Faculty VARCHAR(15),
    PRIMARY KEY (SPC_ID),
    INDEX (SPC_Faculty),
    FOREIGN KEY (SPC_Faculty)
        REFERENCES FACULTY (FCT_ID)
);
ALTER TABLE SPECIALITY CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng CLASS_UNI (Lớp ở trường đại học)
CREATE TABLE IF NOT EXISTS `CLASS_UNI` (
    CLU_ID VARCHAR(15),
    CLU_Speciality VARCHAR(15),
    CLU_Faculty VARCHAR(15),
    PRIMARY KEY (CLU_ID),
    INDEX (CLU_Speciality),
    INDEX (CLU_Faculty),
    FOREIGN KEY (CLU_Speciality)
        REFERENCES SPECIALITY (SPC_ID),
    FOREIGN KEY (CLU_Faculty)
        REFERENCES FACULTY (FCT_ID)
);
ALTER TABLE CLASS_UNI CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng CLASS_HS (Lớp ở trường học phổ thông)
CREATE TABLE IF NOT EXISTS `CLASS_HS` (
    CLHS_ID VARCHAR(20),
    PRIMARY KEY (CLHS_ID)
);
ALTER TABLE CLASS_HS CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng TEACHER_LOGIN để giáo viên hay admin đăng nhập
CREATE TABLE IF NOT EXISTS `TEACHER_LOGIN` (
    STT INT NOT NULL AUTO_INCREMENT,
    Tchr_ID CHAR(10),
    Tchr_Pass CHAR(20) NOT NULL,
    isAdmin BIT NOT NULL,
    Tchr_Type tinyint(1) NOT NULL, -- 1: Phổ thông; 2: Đại học
    PRIMARY KEY (Tchr_ID),
    KEY `STT` (STT)
);
ALTER TABLE TEACHER_LOGIN CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng TEACHER_INFO để lưu trữ thông tin giáo viên
Create table if not exists `TEACHER_INFO`
(
	Tchr_ID char(10) NOT NULL unique,
    Tchr_Name nvarchar(30),
    Tchr_Sex nvarchar (5) Check (Tchr_Sex = N'Nam' Or Tchr_Sex = N'Nữ' Or Tchr_Sex = N'Khác'),
    Tchr_BOD date default '1900-01-01',
    Tchr_Address nvarchar(100) default 'NaN',
    Tchr_Phone char(10) default '',
    Tchr_Mail nvarchar(50) NOT NULL UNIQUE,
    Tchr_Role nvarchar(50) NOT NULL,
    Tchr_inSchool bit default 1, -- 1: Còn công tác tại trường; 0: Đã chuyển đơn vị
    
    Index (Tchr_ID),
    foreign key (Tchr_ID) references TEACHER_LOGIN(Tchr_ID)
);
ALTER TABLE TEACHER_INFO CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng SUBJECT để lưu trữ mã và tên môn học
CREATE TABLE IF NOT EXISTS `SUBJECT` (
    SJ_ID CHAR(5),
    SJ_Name NVARCHAR(50) NOT NULL UNIQUE,
    PRIMARY KEY (SJ_ID)
);
ALTER TABLE `SUBJECT` CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng CLASS_BY_SUBJECT để giáo viên có thể tạo lớp theo môn mình dạy
Create table if not exists `CLASS_BY_SUBJECT`
(
	CBS_ID char(30),
    -- Lấy mã giáo viên tạo môn
    CBS_Tchr_ID char(10) NOT NULL,
    -- Lấy ID của môn học
    CBS_SJ_ID char(5) NOT NULL,
    -- Học kì của lớp đó
    CBS_Semester tinyint(1) NOT NULL,
    -- Năm học của lớp đó
    CBS_Year Year NOT NULL,
    -- Số buổi học của lớp
    CBS_Studies TINYINT(2) NOT NULL,
    
    primary key (CBS_ID),
    INDEX(CBS_Tchr_ID),
    index(CBS_SJ_ID),
     foreign key (CBS_Tchr_ID) references teacher_info(Tchr_ID),
     foreign key (CBS_SJ_ID) references `SUBJECT`(SJ_ID)
);
ALTER TABLE CLASS_BY_SUBJECT CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng  STUDENT_INFO để lưu thông tin của sinh viên ở đại học
Create table if not exists `STUDENT_INFO_UNI`
(
	STT int not null auto_increment,
    STUD_ID char(10),
    STUD_Name nvarchar(30) NOT NULL,
    -- Lấy ID của lớp học ở đại học
    STUD_CLU_ID VARCHAR(15) NOT NULL,
    STUD_BOD date NOT NULL default '1900-01-01',
    STUD_Sex nvarchar(5) not null check (STUD_Sex = N'Nam' or STUD_Sex = N'Nữ' or STUD_Sex = N'Khác'),
    STUD_Address nvarchar(100) default 'NaN',
    STUD_Phone char(10) NOT NULL,
    STUD_Mail nvarchar(50) not null,
	primary key (STUD_ID),
    key `Stud_STT` (STT),
    Index (STUD_CLU_ID),
    foreign key (STUD_CLU_ID) references class_uni(CLU_ID)
);
ALTER TABLE STUDENT_INFO_UNI CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng STUDENT_INFO_HS để lưu trữ thông tin của hs ở phổ thông
Create table if not exists `STUDENT_INFO_HS`
(
	STT int not null auto_increment,
    STUD_ID char(10),
    STUD_Name nvarchar(30) NOT NULL,
    -- Lấy ID của lớp học ở phổ thông
    STUD_CLHS_ID VARCHAR(20) NOT NULL,
    STUD_BOD date NOT NULL default '1900-01-01',
    STUD_Sex nvarchar(5) not null check (STUD_Sex = N'Nam' or STUD_Sex = N'Nữ' or STUD_Sex = N'Khác'),
    STUD_Address nvarchar(100) default 'NaN',
    STUD_Phone char(10) NOT NULL,
    STUD_Mail nvarchar(50) not null,
	primary key (STUD_ID),
    key `Stud_STT` (STT),
    Index (STUD_CLHS_ID),
    foreign key (STUD_CLHS_ID) references class_hs(CLHS_ID)
);
ALTER TABLE STUDENT_INFO_HS CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng STUDENTS_IN_CLASS_UNI để biết học sinh đó học lớp theo môn nào
Create Table if not exists `STUDENTS_IN_CLASS_UNI`
(
	STT int auto_increment,
	-- Lấy ID của sinh viên đại học
	SIC_STUD_ID char(15),
    SIC_STUD_Name nvarchar(30) NOT NULL,
    -- Lấy ID của lớp theo môn
    SIC_CBS_ID char(30) NOT NULL,
    primary key (STT),
    INDEX (SIC_STUD_ID),
    foreign key (SIC_STUD_ID) references student_info_uni(STUD_ID)
);
ALTER TABLE STUDENTS_IN_CLASS_UNI CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng STUDENTS_IN_CLASS_HS để biết học sinh đó học lớp theo môn nào
Create Table if not exists `STUDENTS_IN_CLASS_HS`
(
	STT int auto_increment,
	-- Lấy ID của học sinh phổ thông
	SIC_STUD_ID char(15),
    SIC_STUD_Name nvarchar(30) NOT NULL,
    -- Lấy ID của lớp theo môn
    SIC_CBS_ID char(30) NOT NULL,
    primary key (STT),
    INDEX (SIC_STUD_ID),
    foreign key (SIC_STUD_ID) references student_info_hs(STUD_ID)
);
ALTER TABLE STUDENTS_IN_CLASS_HS CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng STUDY để giáo viên thêm buổi học và giờ học
CREATE TABLE IF NOT EXISTS `STUDY` (
    ID INT,
    Time_Begin TIME NOT NULL,
    Time_End TIME NOT NULL,
    Date_Study DATE NOT NULL,
    Tchr_ID CHAR(10) NOT NULL,
    CBS_ID CHAR(30) NOT NULL,
    INDEX (Tchr_ID),
    INDEX (CBS_ID),
    FOREIGN KEY (Tchr_ID)
        REFERENCES teacher_info (Tchr_ID),
    FOREIGN KEY (CBS_ID)
        REFERENCES class_by_subject (CBS_ID)
); 
ALTER TABLE STUDY CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng STUDY_STATUS_UNI để giáo viên điểm danh sinh viên
CREATE TABLE IF NOT EXISTS `STUDY_STATUS_UNI` (
	-- Lấy ID của sinh viên
    SSU_STUD_ID CHAR(10) NOT NULL,
    SSU_STUD_Name NVARCHAR(30) NOT NULL,
    -- Lấy ID của lớp học theo môn
    SSU_CBS_ID CHAR(30) NOT NULL,
    -- Lấy ID của buổi học đó
    SSU_ID INT NOT NULL,
    Time_In time,
    SSU_Date DATE,
    Roll_call NVARCHAR(15),
    index (SSU_STUD_ID),
    index (SSU_CBS_ID),
    foreign key (SSU_STUD_ID) references student_info_uni(STUD_ID),
    foreign key (SSU_CBS_ID) references class_by_subject(CBS_ID)
);
ALTER TABLE STUDY_STATUS_UNI CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng STUDY_STATUS_UNI để giáo viên điểm danh sinh viên
CREATE TABLE IF NOT EXISTS `STUDY_STATUS_HS` (
	-- Lấy ID của sinh viên
    SSHS_STUD_ID CHAR(10) NOT NULL,
    SSHS_STUD_Name NVARCHAR(30) NOT NULL,
    -- Lấy ID của lớp học theo môn
    SSHS_CBS_ID CHAR(30) NOT NULL,
    -- Lấy ID của buổi học đó
    SSHS_ID INT NOT NULL,
    Time_In Time,
    SSHS_Date DATE,
    Roll_call NVARCHAR(15),
    index (SSHS_STUD_ID),
    index (SSHS_CBS_ID),
    foreign key (SSHS_STUD_ID) references student_info_hs(STUD_ID),
    foreign key (SSHS_CBS_ID) references class_by_subject(CBS_ID)
);
ALTER TABLE STUDY_STATUS_HS CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng DETAIL_MARK_UNI để lưu trữ điểm của sinh viên
CREATE TABLE IF NOT EXISTS `DETAIL_MARK_UNI` (
    DMU_ID INT AUTO_INCREMENT,
    DMU_STUD_ID CHAR(10) NOT NULL,
    DMU_CBS_ID CHAR(30) NOT NULL,
    DMU_Type NVARCHAR(10) NOT NULL CHECK(DMU_Type = N'Thực hành' OR DMU_Type = N'Bài tập' OR DMU_Type = N'Giữa kì' OR DMU_Type = N'Cuối kì'),
    DMU_Mark DECIMAL(4 , 2 ) NOT NULL CHECK (DMU_Mark <= 10 AND DMU_Mark >= 0),
    PRIMARY KEY (DMU_ID),
    INDEX (DMU_STUD_ID),
    INDEX (DMU_CBS_ID),
    FOREIGN KEY (DMU_STUD_ID)
        REFERENCES student_info_uni (STUD_ID),
    FOREIGN KEY (DMU_CBS_ID)
        REFERENCES class_by_subject (CBS_ID)
);
ALTER TABLE DETAIL_MARK_UNI CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng DETAIL_MARK_HS để lưu trữ điểm của học sinh
CREATE TABLE IF NOT EXISTS `DETAIL_MARK_HS` (
    DMHS_ID INT AUTO_INCREMENT,
    DMHS_STUD_ID CHAR(10) NOT NULL,
    DMHS_CBS_ID CHAR(30) NOT NULL,
	DMHS_Type NVARCHAR(15) NOT NULL CHECK(DMHS_Type = N'Thường xuyên' OR DMHS_Type = N'Giữa kì' OR DMHS_Type = N'Cuối kì'),
    DMHS_Mark DECIMAL(4 , 2 ) NOT NULL CHECK (DMHS_Mark <= 10 AND DMHS_Mark >= 0),
    DMHS_Semester tinyint(1) NOT NULL CHECK (DMHS_Semester = 1 OR DMHS_Semester = 2),
    PRIMARY KEY (DMHS_ID),
    INDEX (DMHS_STUD_ID),
    INDEX (DMHS_CBS_ID),
    FOREIGN KEY (DMHS_STUD_ID)
        REFERENCES student_info_hs (STUD_ID),
    FOREIGN KEY (DMHS_CBS_ID)
        REFERENCES class_by_subject (CBS_ID)
);
ALTER TABLE DETAIL_MARK_HS CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng MARKS_UNI để tổng điểm cho sinh viên
CREATE TABLE IF NOT EXISTS `MARKS_UNI` (
    MU_ID INT AUTO_INCREMENT,
    MU_STUD_ID CHAR(10) NOT NULL,
    MU_CBS_ID CHAR(30) NOT NULL,
    -- Điểm giữa kì
    MU_Semi_Mark DECIMAL(4 , 2 ) DEFAULT 0 CHECK (MU_Semi_Mark <= 10 AND MU_Semi_Mark >= 0),
    -- Điểm cuối kì (thi)
    MU_Final_Mark DECIMAL(4 , 2 ) DEFAULT 0 CHECK (MU_Final_Mark <= 10 AND MU_Final_Mark >= 0),
	-- Điểm tổng kết
    MU_GPA DECIMAL(4 , 2 ) DEFAULT 0 CHECK (MU_GPA <= 10 AND MU_GPA >= 0),
    PRIMARY KEY (MU_ID),
    INDEX (MU_STUD_ID),
    INDEX (MU_CBS_ID),
    FOREIGN KEY (MU_STUD_ID)
        REFERENCES student_info_uni (STUD_ID),
    FOREIGN KEY (MU_CBS_ID)
        REFERENCES class_by_subject (CBS_ID)
);
ALTER TABLE MARKS_UNI CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng để lấy % số điểm của từng phần
CREATE TABLE IF NOT EXISTS `MARKS_PERCENT_UNI` (
    MPU_CBS_ID CHAR(30) NOT NULL,
    MPU_Pratice_Percent INT CHECK (MPU_Pratice_Percent >= 0 AND MPU_Pratice_Percent <= 100),
    MPU_Exercise_Percent INT CHECK (MPU_Exercise_Percent >= 0 AND MPU_Exercise_Percent <= 100),
    MPU_Semi_Semester_Percent INT CHECK (MPU_Semi_Semester_Percent >= 0 AND MPU_Semi_Semester_Percent <= 100),
    PRIMARY KEY (MPU_CBS_ID),
    INDEX (MPU_CBS_ID),
    FOREIGN KEY (MPU_CBS_ID)
        REFERENCES `class_by_subject` (CBS_ID)
);
ALTER TABLE MARKS_PERCENT_UNI CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo bảng MARKS_HS để lưu trữ điểm của học sinh
CREATE TABLE IF NOT EXISTS `MARKS_HS` (
    MHS_ID INT AUTO_INCREMENT,
    MHS_STUD_ID CHAR(10) NOT NULL,
    MHS_CBS_ID CHAR(30) NOT NULL,
    -- Điểm học kì 1
    MHS_Semi_Mark DECIMAL(4 , 2 ) DEFAULT 0 CHECK (MHS_Semi_Mark <= 10 AND MHS_Semi_Mark >= 0),
    -- Điểm học kì 2
    MHS_Final_Mark DECIMAL(4 , 2 ) DEFAULT 0 CHECK (MHS_Final_Mark <= 10 AND MHS_Final_Mark >= 0),
	-- Điểm tổng kết
    MHS_GPA DECIMAL(4 , 2 ) DEFAULT 0 CHECK (MHS_GPA <= 10 AND MHS_GPA >= 0),
    PRIMARY KEY (MHS_ID),
    INDEX (MHS_STUD_ID),
    INDEX (MHS_CBS_ID),
    FOREIGN KEY (MHS_STUD_ID)
        REFERENCES student_info_hs (STUD_ID),
    FOREIGN KEY (MHS_CBS_ID)
        REFERENCES class_by_subject (CBS_ID)
);
ALTER TABLE MARKS_HS CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

CREATE TABLE IF NOT EXISTS `writeLog` (
    ID INT AUTO_INCREMENT,
    Activities TEXT,
    onCreated TIMESTAMP,
    PRIMARY KEY (ID)
);
ALTER TABLE `writeLog` CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
/*
SELECT CONCAT("ALTER TABLE ",TABLE_SCHEMA,".",TABLE_NAME," CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;   ",
    "ALTER TABLE ",TABLE_SCHEMA,".",TABLE_NAME," CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;  ") 
    AS alter_sql
FROM information_schema.TABLES
WHERE TABLE_SCHEMA = "myclassroombiden";
*/

-- Tạo trước 1 dòng adminclass_by_subject
insert into myclassroombiden.teacher_login (Tchr_ID, Tchr_Pass, isAdmin, Tchr_Type) Values
(
	'admin', 'admin', 1, 2
);

insert into `teacher_info` (Tchr_ID, Tchr_Mail, Tchr_Role) Values
(
	'admin', 'admin@gmail.com', N'Quản lí hệ thống'
);

-- Tạo PROC để đăng nhập
Drop procedure if exists `sp_teacherLogin` ;
delimiter $$
Create procedure `sp_teacherLogin` (IN ID char(10), IN Pass char(20))
Begin
	IF(Select exists (Select Tchr_ID from `teacher_info` Where ID = Tchr_ID AND Tchr_inSchool = 1)) THEN
    Begin
		Select Tchr_ID
		From myclassroombiden.teacher_login
		Where ID = Tchr_ID AND Pass = Tchr_Pass;
		
		insert myclassroombiden.writelog (Activities, onCreated) values
		((Select concat(ID, N' đã đăng nhập vào hệ thống')), current_timestamp());
	End;
    Else
		Select row_count();
    End if;
End$$
delimiter ;

-- Call `sp_teacherLogin` ('admin', 'admin1');

-- Tạo 1 proc để kiểm tra xem chúng ta có đang trong 1 transaction nào khác k
DELIMITER $$
Drop procedure if exists `mysql`.`require_transaction` $$
CREATE PROCEDURE `mysql`.`require_transaction`()
BEGIN
-- test the session's transactional status, 
-- throwing an exception if we aren't in a transaction,
-- but finishing successfully if we are
DECLARE CONTINUE HANDLER 
        FOR 1305 
        SIGNAL SQLSTATE '42000' 
        SET MESSAGE_TEXT = 'you must have an active database transaction before attempting this operation';

SAVEPOINT `we created to be sure you were in a transaction`;
ROLLBACK TO SAVEPOINT `we created to be sure you were in a transaction`;

END$$
DELIMITER ;
/*
start transaction;
call `mysql`.`require_transaction`;
rollback;
call `mysql`.`require_transaction`;
*/

-- PROC để admin tạo 1 teacher mới
Drop procedure if exists `sp_insertTeacher`;
DELIMITER $$
Create procedure `sp_insertTeacher` (	currID CHAR(10),
										setEmail VARCHAR(30), 
										Pass CHAR(20),
                                        setType tinyint, 
                                        setAdmin bit,
                                        setRole varchar(50))
Begin
	DECLARE exit handler for SQLEXCEPTION, sqlwarning
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
		SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
		SELECT @full_error;
	END;
    -- Kiểm tra xem có gmail đó tồn tại trong teacher_info hay chưa, vì 1 người chỉ dùng 1 tài khoản email
    -- Nếu chưa thì thêm thông tin chỗ if, còn r thì xuất ra thông báo thêm k thành công
	if ((Select not exists(select * from myclassroombiden.teacher_info where Tchr_Mail = setEmail))
		and setEmail <> ' ' and (Select instr(setEmail, '@') <> 0)) Then
	Begin
		select max(STT) + 1 into @ID from myclassroombiden.teacher_login;
        
		insert `teacher_login` (Tchr_ID, Tchr_Pass, isAdmin, Tchr_Type) values
        ((Select concat("GV", @ID)), Pass, setAdmin, setType);
        
        insert `teacher_info` (Tchr_ID, Tchr_Mail, Tchr_Role) values
        ((Select concat("GV", @ID)), setEmail, setRole);
        --  sau khi thêm 2 bảng bên trên thì ghi log để biết giáo viên nào đc thêm và thêm bởi ai
        insert `writelog` (Activities, onCreated) values
        ((Select concat("GV", @ID, N' đã được thêm vào hệ thống bởi ', currID)), current_timestamp());
        
        Select row_count();
    end;
    else
		Select row_count();
    end if;
		
End$$
DELIMITER ;
/*
call myclassroombiden.sp_insertTeacher('admin',N'm@gmail.com', N'123', 2, 0, N'Giáo viên');
Set @test = 'asdsadasd';
Select instr(@test, '@');

Select * From myclassroombiden.teacher_login;
Select * from myclassroombiden.teacher_info;
Select * from writelog;
*/
/*
SELECT param_list FROM mysql.proc WHERE db='myclassroombiden' AND name='sp_insertTeacher';
SELECT * 
FROM information_schema.parameters 
WHERE SPECIFIC_NAME = 'myclassroombiden';
*/
-- Tạo proc để update thông tin của giáo viên
DELIMITER $$
drop procedure if exists `sp_updateTeacher` $$
Create procedure `sp_updateTeacher` ( 	getID char(10),
										setName varchar(30),
										setSex varchar(5),
                                        setBOD date,
                                        setAddr varchar(100),
                                        setPhone char(10),
                                        setMail varchar(50))
Begin
	DECLARE exit handler for SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
		SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
		SELECT @full_error;
	END;
    start transaction;
    set autocommit = 0;
	Begin
		IF (Select exists (Select Tchr_ID
							From `teacher_info`
                            Where Tchr_ID = getID)) THEN
		Begin 
			-- Nếu các tham số truyền vào là null hay rỗng, và k phải định dạng mail thì sẽ k đc update thông tin
			if (((setName Or setSex Or setBOD Or setAddr Or setPhone) <> ' ')
				and (select instr(setMail, '@') <> 0)
				and (select setPhone regexp '^[0-9]+$') <> 0) THEN
			Begin
				Update `teacher_info`
				Set Tchr_Name = IFNULL(setName, "NaN"),
					Tchr_Sex = setSex,
					Tchr_BOD = setBOD,
					Tchr_Address = IFNULL(setAddr, "NaN"),
					Tchr_Phone = setPhone,
					Tchr_Mail = setMail
				Where Tchr_ID = getID;
				-- Ghi vào log để biết giáo viên nào đã cập nhật thông tin của mình
				insert `writelog` (Activities, onCreated) values
				((Select concat(getID, " đã cập nhật thông tin")), current_timestamp());
				
				Select row_count();
				commit;
			End;
			else
			Begin
				Select row_count();
				rollback;
			End;
			End if;
		End;
		Else
        Begin 
			Select row_count();
            rollback;
        End;
        End if;
	End;
End$$
DELIMITER ;

-- Tạo proc để đổi mật khẩu cho giáo viên
DELIMITER $$
Drop procedure if exists `sp_changePassword` $$
Create procedure `sp_changePassword` (	IN currID char(10),
										IN newPass char(30),
                                        IN cfmPass char(30))
Begin
	DECLARE exit handler for SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
		SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
		SELECT @full_error;
	END;
    start transaction;
    set autocommit = 0;
    if (Cast((Select length(newPass)) + (Select length(cfmPass)) as signed) <> 0) THEN
	Begin
		IF((Select strcmp(newPass, cfmPass) = 0)
			AND Cast((Select length(newPass)) + (Select length(cfmPass)) as signed) <> 0) Then
        Begin
			Update `teacher_login`
            Set Tchr_Pass = newPass
            Where Tchr_ID = currID;
            -- Ghi vào log để ghi nhận việc cập nhật mật khẩu thành công của giáo viên
            insert `writelog` (Activities, onCreated) values
			((Select concat(currID, " đã cập nhật tài khoản thành công")), current_timestamp()); 
            
            Select row_count();
            commit;
        End;
        else
        Begin
			Select row_count();
			rollback;
		End;
        End if;
    End;
    else
		Select row_count();
        rollback;
    End if;
End$$ 
DELIMITER ;
/*
	**** Code mẫu cho proc sp_updatePassword ****
								ID - Mk mới - Xác nhận mk mới
    call `sp_updatePasswork` ('GV2', '5678', '5678')
*/

-- Tạo proc để update role của giáo viên và update còn làm tại trường hay không
DELIMITER $$
Drop procedure if exists `sp_updateRole_Work` $$
Create procedure `sp_updateRole_Work` (currID char(10),
										getID char(10),
										updRole varchar(50),
                                        updInSkl bit)
Begin
	DECLARE exit handler for SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
		SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
		SELECT @full_error;
	END;
    start transaction;
    set autocommit = 0;
    IF ((Select length(updRole)) > 0 AND (updInSkl = 1 OR updInSkl = 0)) THEN
    Begin
		Update `teacher_info`
        Set Tchr_Role = updRole,
			Tchr_inSchool = updInSkl
		Where getID = Tchr_ID;
        
        insert `writelog` (Activities, onCreated) values
        (CONCAT(currID, " đã cập nhật Role và inSchool thành công cho ", getID), current_timestamp());
        
        Select row_count();
        commit;
    End;
    else
    Begin
		Select row_count();
        rollback;
    End;
    End if;
End$$
DELIMITER ;
/*
	**** Code mẫu cho proc sp_updateRole_Work ****
							admin ID -  GV ID -  Role 	- inSchool    -- inSchool là tình trạng còn công tác tại trường hay k -- 1: Còn; 0: Đã chuyển đơn vị
    call `sp_updateRole_Work` ('admin', 'GV2', 'Giám đốc', '1')
*/

-- Tạo proc để thêm khoa cho admin nếu là type đại học 
DELIMITER $$
Drop procedure if exists `sp_insertFaculty` $$
Create procedure `sp_insertFaculty` (currID char(10),
										fac_ID char(15),
                                        fac_Name varchar(30))
Begin
	DECLARE exit handler for SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
		SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
		SELECT @full_error;
	END;
    start transaction;
    set autocommit = 0;
    Begin
		IF (Select exists (Select Tchr_ID 
							From `teacher_login` 
							Where Tchr_ID = currID 
									AND Tchr_Type = 2 
                                    AND isAdmin = 1)) THEN
        Begin
			IF (Select not exists (Select *
								FROM `faculty`
                                Where FCT_ID = fac_ID)) THEN
			Begin
				Insert `faculty` (FCT_ID, FCT_Name) values
				(fac_ID, fac_Name);
				
				insert `writelog` (Activities, onCreated) values
				(concat(currID, " đã tạo ", fac_Name, " với mã là: ", fac_ID), current_timestamp());
				
				Select row_count();
				commit;
			End;
            Else
            Begin
				select row_count();
                rollback;
            End;
            End if;
        End;
        else
        Begin
			Select row_count();
            rollback;
		End;
        End if;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
							Admin ID - Mã Khoa - 	Tên khoa
    call `sp_insertFaculty` ('admin', 'CNTT', 'Khoa Công nghệ thông tin');
*/

-- Tạo proc để thêm chuyên ngành ở đại học 
DELIMITER $$
Drop procedure if exists `sp_insertSpeciality` $$
Create procedure `sp_insertSpeciality` (currID char(10),
										spc_ID char(15),
                                        spc_Name varchar(30),
                                        fac_ID char(15))
Begin
	DECLARE exit handler for SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
		SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
		SELECT @full_error;
	END;
    start transaction;
    set autocommit = 0;
    Begin
		IF(Select exists (Select FCT_ID From `faculty` Where FCT_ID = fac_ID)) THEN
        Begin
			IF(Select exists (Select Tchr_ID 
							From `teacher_login` 
							Where Tchr_ID = currID 
									AND Tchr_Type = 2 
                                    AND isAdmin = 1)) THEN
			Begin
				Insert `speciality` (SPC_ID, SPC_Name, SPC_Faculty) Values
                (spc_ID, spc_Name, fac_ID);
                
                insert `writelog` (Activities, onCreated) values
                (CONCAT(currID, " đã tạo ", spc_Name, " với mã là: ", spc_Name), current_timestamp());
                
                Select row_count();
                commit;
            End;
            else
			Begin
				Select row_count();
                rollback;
            End;
            End IF;
        End;
        Else
        Begin
			Select row_count();
            rollback;
        End;
        End if;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
											Admin ID - Mã CN - 	Tên Chuyên ngành -  Mã khoa
    call myclassroombiden.sp_insertSpeciality('admin', 'KTPM', 'Kỹ thuật phần mềm', 'CNTT');

*/

-- Tạo proc để admin tạo lớp ở đại học
DELIMITER $$
Drop procedure if exists `sp_insertClass_UNI` $$
Create procedure `sp_insertClass_UNI` (currID char(10),
										clu_ID char(15),
                                        spc_ID char(15),
                                        fac_ID char(15))
Begin
	DECLARE exit handler for SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
		SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
		SELECT @full_error;
	END;
    start transaction;
    set autocommit = 0;
    Begin
		IF(Select exists (Select FCT_ID From `faculty` Where FCT_ID = fac_ID)
			AND (Select exists (Select SPC_ID From `speciality` Where SPC_ID = spc_ID))) THEN
        Begin
			IF(Select exists (Select Tchr_ID 
							From `teacher_login` 
							Where Tchr_ID = currID 
									AND Tchr_Type = 2 
                                    AND isAdmin = 1)) THEN
			Begin
				IF (Select not exists (Select *
									From `class_uni`
									Where CLU_ID = clu_ID)) THEN
				Begin
					insert `class_uni` (CLU_ID, CLU_Speciality, CLU_Faculty) values
					(clu_ID, spc_ID, fac_ID);
					
					insert `writelog` (Activities, onCreated) values
					(CONCAT(currID, " đã tạo lớp với mã là: ", clu_ID), current_timestamp());
					
					Select row_count();
					commit;
				End;
                Else
                Begin
					Select row_count();
                    rollback;
                End;
                End if;
            End;
            else
			Begin
				Select row_count();
                rollback;
            End;
            End IF;
        End;
        Else
        Begin
			Select row_count();
            rollback;
        End;
        End if;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
											Admin ID - Mã lớp - Mã CN -  Mã khoa
    call myclassroombiden.sp_insertSpeciality('admin', 'D19PM02', 'KTPM', 'CNTT');

*/

-- Tạo proc để Admin tạo lớp ở phổ thông
DELIMITER $$
Drop procedure if exists `sp_insertClass_HS` $$
Create procedure `sp_insertClass_HS` (	currID char(10),
										ID char(15))
Begin
	DECLARE exit handler for SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
		SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
		SELECT @full_error;
	END;
    start transaction;
    set autocommit = 0;
    Begin
		IF(Select exists (Select Tchr_ID 
						From `teacher_login` 
						Where Tchr_ID = currID 
								AND Tchr_Type = 1 
								AND isAdmin = 1)) THEN
		Begin
			IF (Select not exists (Select *
									From `class_hs`
                                    Where CLHS_ID = ID)) THEN
			Begin
				insert `class_hs` (CLHS_ID) values
				(ID);
				
				insert `writelog` (Activities, onCreated) values
				(CONCAT(currID, " đã tạo lớp với mã là: ", ID), current_timestamp());
				
				Select row_count();
				commit;
			End;
            else
            Begin
				Select row_count();
                rollback;
            End;
            End if;
		End;
		else
		Begin
			Select row_count();
			rollback;
		End;
		End IF;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
											Admin ID -	 Mã lớp
    call myclassroombiden.sp_insertSpeciality('admin', 'Lop12_04_2020');

*/

-- Tạo proc để admin có thể thêm sinh viên, học sinh
DELIMITER $$
Drop procedure if exists `sp_insertStudent` $$
Create procedure `sp_insertStudent` (	ad_ID char(10),
										setName varchar(30),
                                        getClass_ID longtext,
                                        setBOD date,
                                        setSex varchar(5),
                                        setAddr varchar(100),
                                        setPhone char(10),
                                        setMail varchar(50))
Begin
	DECLARE exit handler for SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
		SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
		SELECT @full_error;
	END;
    start transaction;
    set autocommit = 0;
    Begin
		-- Đây là add sv 
		if (Select exists (Select Tchr_ID 
						From `teacher_login` 
						Where Tchr_ID = ad_ID 
								AND Tchr_Type = 2
								AND isAdmin = 1)) THEN
		Begin
			if((Select instr(setMail, '@') <> 0) AND (Select setPhone REGEXP '^[0-9]+$') <> 0) THEN
            Begin
				Select ifnull(max(STT), 0) + 1 into @ID From `student_info_uni`;
				
				Insert `student_info_uni` (STUD_ID, STUD_Name, STUD_CLU_ID, STUD_BOD, STUD_Sex, STUD_Address, STUD_Phone, STUD_Mail) Values
				(concat("SV", @ID), setName, getClass_ID, setBOD, setSex, setAddr, setPhone, setMail);
				
				Insert `writelog` (Activities, onCreated) Values
				(concat(ad_ID, " vừa thêm sinh viên với mã là: ", Concat("SV", @ID), " , tên: ", setName, " , lớp: ", getClass_ID), current_timestamp());
				
				Select row_count();
                commit;
            End;
            else
			Begin
				Select row_count();
                rollback;
            End;
            End if;
        End;
        
        -- Thêm 1 học sinh danh cho admin bên thpt
        elseif (Select exists (Select Tchr_ID 
						From `teacher_login` 
						Where Tchr_ID = ad_ID 
								AND Tchr_Type = 1
								AND isAdmin = 1)) THEN
        Begin
			if((Select instr(setMail, '@') <> 0) AND (Select setPhone REGEXP '^[0-9]+$') <> 0) THEN
            Begin
				Select ifnull(max(STT), 0) + 1 into @ID From `student_info_hs`;
				
				Insert `student_info_hs` (STUD_ID, STUD_Name, STUD_CLHS_ID, STUD_BOD, STUD_Sex, STUD_Address, STUD_Phone, STUD_Mail) Values
				(concat("HS", @ID), setName, getClass_ID, setBOD, setSex, setAddr, setPhone, setMail);
				
				Insert `writelog` (Activities, onCreated) Values
				(concat(ad_ID, " vừa thêm học sinh với mã là: ", Concat("HS", @ID), " , tên: ", setName, " , lớp: ", getClass_ID), current_timestamp());
				
				Select row_count();
                commit;
            End;
            else
			Begin
				Select row_count();
                rollback;
            End;
            End if;
        End;
        
        else
        Begin
			Select row_count();
            rollback;
        End;
        end if;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
-- Đây là gọi procedure mẫu cho thêm sinh viên
										Admin ID - Tên sv - 	Mã lớp - 	BOD - 	Giới tính - Địa chỉ - 	SĐT - 			Gmail
call myclassroombiden.sp_insertStudent('admin', 'Hảo Hảo', 'D19QTKD', '2000-12-09', 'Nam', 'Bến Tre', '0123465798', 'HaoHao@gmail.com');
-- Đây là gọi procedure mẫu cho thêm học sinh
										Admin ID - Tên hs - 		Mã lớp - 		BOD - 	Giới tính -	Địa chỉ - 	SĐT - 			Gmail
call myclassroombiden.sp_insertStudent('GV3', 'Trần Thị Xoài', 'Lop12_02_2020', '2000-06-12', 'Nữ', 'Tiền Giang', '0123465798', 'Xoai@gmail.com');
-- Chú thích thêm: Hssv đc được thêm dựa vào loại admin đang tạo, nếu là đại học thì sẽ tạo sv, thpt thì sẽ tạo hs
*/

DELIMITER $$
Drop procedure if exists `sp_updateStudent` $$
Create procedure `sp_updateStudent` (	ad_ID char(10),
										getID varchar(30),
										setName varchar(30),
                                        getClass_ID longtext,
                                        setBOD date,
                                        setSex varchar(5),
                                        setAddr varchar(100),
                                        setPhone char(10),
                                        setMail varchar(50))
Begin
	DECLARE exit handler for SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
		SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
		SELECT @full_error;
	END;
    start transaction;
    set autocommit = 0;
    Begin
		-- Cập nhật sinh viên
		if (Select exists (Select Tchr_ID 
							From `teacher_login` 
							Where Tchr_ID = ad_ID 
									AND Tchr_Type = 2
									AND isAdmin = 1)
			AND (Select exists (Select STUD_ID
								FROM `student_info_uni`
                                Where STUD_ID = getID))) THEN
		Begin
			if((Select instr(setMail, '@') <> 0) AND (Select setPhone REGEXP '^[0-9]+$') <> 0) THEN
            Begin
				Update `student_info_uni`
                Set STUD_Name = setName,
					STUD_CLU_ID = getClass_ID,
                    STUD_BOD = setBOD,
                    STUD_Sex = setSex,
                    STUD_Address = setAddr,
                    STUD_Phone = setPhone,
                    STUD_Mail = setMail
                Where STUD_ID = getID;
				Insert `writelog` (Activities, onCreated) Values
				(concat(ad_ID, " vừa cập nhật sinh viên với mã là: ", getID), current_timestamp());
				
				Select row_count();
                commit;
            End;
            else
			Begin
				Select row_count();
                rollback;
            End;
            End if;
        End;
        
        -- Cập nhật học sinh ở thpt
        elseif (Select exists (Select Tchr_ID 
						From `teacher_login` 
						Where Tchr_ID = ad_ID 
								AND Tchr_Type = 1
								AND isAdmin = 1)
				AND (Select exists (Select STUD_ID
									FROM `student_info_hs`
									Where STUD_ID = getID))) THEN
        Begin
			if((Select instr(setMail, '@') <> 0) AND (Select setPhone REGEXP '^[0-9]+$') <> 0) THEN
            Begin
				Update `student_info_hs`
                Set STUD_Name = setName,
					STUD_CLHS_ID = getClass_ID,
                    STUD_BOD = setBOD,
                    STUD_Sex = setSex,
                    STUD_Address = setAddr,
                    STUD_Phone = setPhone,
                    STUD_Mail = setMail
                Where STUD_ID = getID;
				
				Insert `writelog` (Activities, onCreated) Values
				(concat(ad_ID, " vừa cập nhật học sinh với mã là: ", getID), current_timestamp());
				
				Select row_count();
                commit;
            End;
            else
			Begin
				Select row_count();
                rollback;
            End;
            End if;
        End;
        
        else
        Begin
			Select row_count();
            rollback;
        End;
        end if;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
-- Đây là gọi procedure mẫu cho thêm sinh viên
									Admin ID - 	Mã SV -	Tên sv - 	Mã lớp - 	BOD - 	Giới tính - Địa chỉ - 	SĐT - 			Gmail
call myclassroombiden.sp_updateStudent('admin', 'SV1',  'Lê Văn Lé', 'D19KT02', '2000-05-01', 'Nam', 'Đồng Tháp', '0123465798', 'Le@gmail.com');
-- Đây là gọi procedure mẫu cho thêm học sinh
									Admin ID - Mã SV - Tên hs - 		Mã lớp - 		BOD - 	Giới tính -	Địa chỉ - 	SĐT - 			Gmail
call myclassroombiden.sp_updateStudent('GV3', 'HS1','Trần Thị Bưởi', 'Lop12_04_2020', '2000-06-12', 'Nữ', 'Tiền Giang', '0123465798', 'Le@gmail.com');
*/

-- Tạo proc xoá học sinh sinh viên
DELIMITER $$
Drop procedure if exists `sp_deleteStudent` $$
Create procedure `sp_deleteStudent` (ad_ID char(10),
										getID_Stud char(10))
Begin
	DECLARE exit handler for SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
		SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
		SELECT @full_error;
	END;
    start transaction;
    set autocommit = 0;
    Begin
		if (Select exists (Select Tchr_ID 
							From `teacher_login` 
							Where Tchr_ID = ad_ID 
									AND Tchr_Type = 2
									AND isAdmin = 1)
			AND (Select exists (Select *
								FROM `student_info_uni`
                                Where STUD_ID = getID_Stud))) THEN
		Begin
			Delete From `student_info_uni`
            Where getID_Stud = STUD_ID;
            
            Insert	`writelog` (Activities, onCreated) Values
            (Concat(ad_ID, " vừa xoá một sinh viên với mã là: ", getID_Stud), current_timestamp());
            
            Select row_count();
            commit;
        End;
        elseif (Select exists (Select Tchr_ID 
						From `teacher_login` 
						Where Tchr_ID = ad_ID 
								AND Tchr_Type = 1
								AND isAdmin = 1)
				AND (Select exists (Select *
									FROM `student_info_hs`
									Where STUD_ID = getID_Stud))) THEN
		Begin
			Delete From `student_info_uni`
			Where getID_Stud = STUD_ID;
			
			Insert	`writelog` (Activities, onCreated) Values
			(Concat(ad_ID, " vừa xoá một học sinh với mã là: ", getID_Stud), current_timestamp());
			
			Select row_count();
			commit;
        End;
        else
        Begin
			Select row_count();
            rollback;
        End;
        End if;
    End;
End$$
DELIMITER ;

-- Tạo proc thêm và sửa môn học cho admin
DELIMITER $$
Drop procedure if exists `sp_ins_updSubject` $$
Create procedure `sp_ins_updSubject` (ad_ID char(10),
										s_ID char(5),
                                        s_Name varchar(50))
Begin
	DECLARE exit handler for SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
		SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
		SELECT @full_error;
	END;
    start transaction;
    set autocommit = 0;
    Begin
		IF (Select exists (Select Tchr_ID 
							From `teacher_login` 
							Where Tchr_ID = ad_ID
									AND isAdmin = 1)) Then
		Begin
			IF (Select not exists (Select *
									From `subject`
									Where s_ID = SJ_ID)) THEN
			Begin
				Insert `subject` (SJ_ID, SJ_Name) values
				(s_ID, s_Name);
				
				insert `writelog` (Activities, onCreated) Values
				(concat(ad_ID, " đã tạo môn học với mã là: ", s_ID, " , tên là: ", s_Name), current_timestamp());
				
                select row_count();
				Commit;
			End;
			Else
			Begin
				Update `subject`
				Set SJ_Name = s_Name
				Where SJ_ID = s_ID;
				
				insert `writelog` (Activities, onCreated) Values
				(concat(ad_ID, " đã cập nhật môn học với mã là: ", s_ID, " , thành tên là: ", s_Name), current_timestamp());
				
                select row_count();
				Commit;
                End;
            End IF;
		End;
        else
        Begin
			select row_count();
            rollback;
        End;
        End if;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
										Admin ID - ID môn học - Tên môn học
call myclassroombiden.sp_ins_updSubject('admin', 'TI096', 'Quản lí dự án công nghệ thông tin');
*/

DELIMITER $$
Drop procedure if exists `sp_deleteSubject` $$
Create procedure `sp_deleteSubject` (	ad_ID char(10),
										sub_ID char(5))
Begin
	DECLARE exit handler for SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
		SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
		SELECT @full_error;
	END;
    start transaction;
    set autocommit = 0;
    Begin
		IF (Select exists (Select Tchr_ID 
							From `teacher_login`
							Where Tchr_ID = ad_ID)
			AND (Select exists (Select * 
								From `subject` 
                                where sub_ID = SJ_ID))) THEN
		Begin
			Delete From `subject`
            Where SJ_ID = sub_ID;
            
            insert `writelog` (Activities, onCreated) values
            (Concat(ad_ID, " đã xoá môn học: ", sub_ID), current_timestamp());
            
            Select row_count();
            Commit;
        End;
        Else
        Begin
			Select row_count();
            rollback;
        End;
        end if;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
										Admin ID - ID môn học
call myclassroombiden.sp_deleteSubject('admin', 'TI100');
*/

DELIMITER $$
Drop procedure if exists `sp_ins_updClass_by_Sub` $$
Create procedure `sp_ins_updClass_by_Sub` (	ID char(30),
											AD_ID char(10),
											Teacher_ID char(10),
                                            sj_ID char(5),
                                            Semester tinyint(1),
                                            tYear year,
                                            Studies tinyint(2))
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
    start transaction;
    set autocommit = 0;
    Begin
		IF (Select exists (Select Tchr_ID 
							From `teacher_login` 
							Where Tchr_ID = AD_ID
									AND isAdmin = 1)) THEN
		Begin
			-- Update nếu có đó tồn tại
			IF(Select exists (Select *
								From `class_by_subject`
								Where CBS_ID = ID)) THEN
			Begin
				Update `class_by_subject`
				Set CBS_SJ_ID = sj_ID,
					CBS_Tchr_ID = Teacher_ID,
					CBS_Semester = Semester,
					CBS_Year = tYear,
					CBS_Studies = Studies
				Where CBS_ID = ID;
				
				Insert `writelog` (Activities, onCreated) Values
				(concat(AD_ID, " đã cập nhật thông tin của mã lớp theo môn: ", ID, " , của giáo viên: ", Teacher_ID), current_timestamp());
				
				Select row_count();
				Commit;
			End;
			-- Thêm nếu chưa có mã đó
			ElseIF(Select not exists (Select *
										From `class_by_subject`
										Where CBS_ID = ID)) THEN
			Begin
				insert `class_by_subject` (CBS_ID, CBS_Tchr_ID, CBS_SJ_ID, CBS_Semester, CBS_Year, CBS_Studies) Values
				(ID, Teacher_ID, sj_ID, Semester, tYear, Studies);
				
				insert `writelog` (Activities, onCreated) Values
				(Concat(AD_ID, " đã tạo lớp theo môn với mã là: ", ID, " cho giáo viên: ", Teacher_ID), current_timestamp());
					
				Select row_count();
				commit;
			End;
			Else
			Begin
				Select row_count();
				rollback;
			End;
			End IF;
		End;
        Else
		Begin
			Select row_count();
            rollback;
        End;
        END IF;
	End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
												ID Lớp theo môn - AD ID -  GV ID - Môn ID - Học kì - Năm học - Buổi học 
call myclassroombiden.sp_ins_updClass_by_Sub('TI_098_CQ_02_2020', 'admin', GV2,	  'TI098', 	 1, 	  2021, 	14);
-- Lưu ý: Lấy ID của giáo viên đang đăng nhập để tạo mã lớp
*/

-- Tạo proc để giáo viên có thể xoá ID của Class_by_Subject nếu muốn
DELIMITER $$
Drop procedure if exists `sp_deleteClass_by_Sub` $$
Create procedure `sp_deleteClass_by_Sub` (AD_ID char(10),
											ID char(30))
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
    start transaction;
    set autocommit = 0;
    Begin
		if(Select exists (Select *
							From `class_by_subject`
                            Where ID = CBS_ID)
			AND (Select exists (Select Tchr_ID
								From `teacher_login`
                                Where Tchr_ID = AD_ID))) THEN
		Begin
			delete from `class_by_subject`
            where CBS_ID = ID;
            
            insert `writelog` (Activities, onCreated) Values
            (Concat(AD_ID, " đã xoá mã lớp: ", ID), current_timestamp());
            
            Select row_count();
            commit;
        End;
        else
        Begin
			Select row_count();
            rollback;
        End;
        end if;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
											GV ID - ID lớp theo môn
call myclassroombiden.sp_deleteClass_by_Sub('admin', 'TI123');
-- Lưu ý: GV ID là lấy ID đăng nhập của giáo viên bất kì, và chỉ người đó tạo thì mới đc xoá
*/

-- Tạo proc để admin có thể thêm học sinh vào lớp học theo môn
DELIMITER $$
drop procedure if exists `sp_insertStudInClassBySub_hs` $$
create procedure `sp_insertStudInClassBySub_hs` (AD_ID char(10),
												 Student_ID char(10),
                                                 ClassBySub_ID char(30))
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
    start transaction;
    set autocommit = 0;
    Begin
		IF (Select exists(Select Tchr_ID
							From `teacher_login`
                            Where Tchr_ID = AD_ID
									AND isAdmin = 1
                                    AND Tchr_Type = 1)) THEN
		Begin
			IF (Select not exists (Select *
									From `students_in_class_hs`
									Where SIC_STUD_ID = Student_ID
											AND SIC_CBS_ID = ClassBySub_ID)) THEN
			Begin
				Insert `students_in_class_hs` (SIC_STUD_ID, SIC_STUD_Name, SIC_CBS_ID) values
				(Student_ID, (Select STUD_Name FROM `student_info_hs` Where Student_ID = STUD_ID), ClassBySub_ID);
                
                insert `marks_hs` (MHS_STUD_ID, MHS_CBS_ID) Values
                (Student_ID, ClassBySub_ID);
				
				Insert `writelog` (Activities, onCreated) Values
				(Concat(AD_ID, " đã thêm học sinh: ", Student_ID, " vào lớp theo môn: ", ClassBySub_ID), current_timestamp());
				
				Select row_count();
				commit;
			End;
			Else
			Begin
				Select row_count();
				rollback;
			End;
			End IF;
		End;
		Else
        Begin
			Select row_count();
			rollback;
        End;
        End IF;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
													AD ID - HS ID - Mã lớp theo môn
call myclassroombiden.sp_insertStudInClassBySub_hs('GV3', 	'HS7', 'Van_Lop12_a4_2021_2022');
*/

-- Tạo proc để admin xoá một học sinh trong lớp theo môn
DELIMITER $$
drop procedure if exists `sp_deleteStudInClassBySub_hs` $$
create procedure `sp_deleteStudInClassBySub_hs` (AD_ID char(10),
												 Student_ID char(10),
                                                 ClassBySub_ID char(30))
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
    start transaction;
    set autocommit = 0;
    Begin
		IF (Select exists(Select Tchr_ID
							From `teacher_login`
                            Where Tchr_ID = AD_ID
									AND isAdmin = 1
                                    AND Tchr_Type = 1)) THEN
		Begin
			IF (Select exists (Select *
								From `students_in_class_hs`
								Where SIC_STUD_ID = Student_ID
										AND SIC_CBS_ID = ClassBySub_ID)) THEN
			Begin
				Delete From `students_in_class_hs`
                Where SIC_STUD_ID = Student_ID
						AND SIC_CBS_ID = ClassBySub_ID;
				
                Delete From `marks_hs`
                Where SIC_STUD_ID = Student_ID
						AND SIC_CBS_ID = ClassBySub_ID;
				
				Insert `writelog` (Activities, onCreated) Values
				(Concat(AD_ID, " đã xoá học sinh: ", Student_ID, " ở lớp theo môn: ", ClassBySub_ID), current_timestamp());
				
				Select row_count();
				commit;
			End;
			Else
			Begin
				Select row_count();
				rollback;
			End;
			End IF;
		End;
		Else
        Begin
			Select row_count();
			rollback;
        End;
        End IF;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
													AD ID - HS ID - Mã lớp theo môn
call myclassroombiden.sp_insertStudInClassBySub_hs('GV3', 	'HS7', 'Van_Lop12_a4_2021_2022');
*/

-- Tạo proc để admin có thể thêm sinh viên vào lớp học theo môn
DELIMITER $$
drop procedure if exists `sp_insertStudInClassBySub_uni` $$
create procedure `sp_insertStudInClassBySub_uni` (AD_ID char(10),
												 Student_ID char(10),
                                                 ClassBySub_ID char(30))
Begin
	DECLARE MYUSERID SMALLINT;
	DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN END;
	SET @inserted_rows = 0;
	SET @updated_rows = 0;
    start transaction;
    set autocommit = 0;
    Begin
		IF (Select exists(Select Tchr_ID
							From `teacher_login`
                            Where Tchr_ID = AD_ID
									AND isAdmin = 1
                                    AND Tchr_Type = 2)) THEN
		Begin
			IF (Select not exists (Select *
									From `students_in_class_uni`
									Where SIC_STUD_ID = Student_ID
											AND SIC_CBS_ID = ClassBySub_ID)) THEN
			Begin
				Insert `students_in_class_uni` (SIC_STUD_ID, SIC_STUD_Name, SIC_CBS_ID) values
				(Student_ID, (Select STUD_Name FROM `student_info_uni` Where Student_ID = STUD_ID), ClassBySub_ID);
                
                insert `marks_uni` (MU_STUD_ID, MU_CBS_ID) Values
                (Student_ID, ClassBySub_ID);
				
				Insert `writelog` (Activities, onCreated) Values
				(Concat(AD_ID, " đã thêm sinh viên: ", Student_ID, " vào lớp theo môn: ", ClassBySub_ID), current_timestamp());
                
                Select row_count();
				commit;
			End;
			Else
			Begin
				Select row_count();
				rollback;
			End;
			End IF;
		End;
		Else
        Begin
			Select row_count();
			rollback;
        End;
        End IF;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ***   *
													AD ID - HS ID - Mã lớp theo môn
call myclassroombiden.sp_insertStudInClassBySub_uni('admin', 'SV4', 'TI098_HK1_CQ02_2021');
*/

-- Tạo proc để admin xoá một sinh viên trong lớp theo môn
DELIMITER $$
drop procedure if exists `sp_deleteStudInClassBySub_uni` $$
create procedure `sp_deleteStudInClassBySub_uni` (AD_ID char(10),
												 Student_ID char(10),
                                                 ClassBySub_ID char(30))
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
    start transaction;
    set autocommit = 0;
    Begin
		IF (Select exists(Select Tchr_ID
							From `teacher_login`
                            Where Tchr_ID = AD_ID
									AND isAdmin = 1
                                    AND Tchr_Type = 2)) THEN
		Begin
			IF (Select exists (Select *
								From `students_in_class_uni`
								Where SIC_STUD_ID = Student_ID
										AND SIC_CBS_ID = ClassBySub_ID)) THEN
			Begin
				Delete From `students_in_class_uni`
                Where SIC_STUD_ID = Student_ID
						AND SIC_CBS_ID = ClassBySub_ID;
				
                Delete From `marks_uni`
				Where SIC_STUD_ID = Student_ID
						AND SIC_CBS_ID = ClassBySub_ID;
				
				Insert `writelog` (Activities, onCreated) Values
				(Concat(AD_ID, " đã xoá sinh viên: ", Student_ID, " ở lớp theo môn: ", ClassBySub_ID), current_timestamp());
				
				Select row_count();
				commit;
			End;
			Else
			Begin
				Select row_count();
				rollback;
			End;
			End IF;
		End;
		Else
        Begin
			Select row_count();
			rollback;
        End;
        End IF;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
													AD ID - HS ID - Mã lớp theo môn
call myclassroombiden.sp_deleteStudInClassBySub_uni('admin', 'SV4', 'TI098_HK1_CQ03_2021');
*/

-- Tạo proc để giáo viên thêm buổi học trước giờ dạy
DELIMITER $$
Drop procedure if exists `sp_ins_updStudy` $$
Create procedure `sp_ins_updStudy` (studies int,
									Begins time,
									Finish time,
                                    onDate date,
                                    teacher_ID char(10),
                                    ClassBySub_ID char(30))
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
    start transaction;
    set autocommit = 0;
    Begin
		IF (Select exists (Select Tchr_ID
							From `teacher_login`
                            Where teacher_ID = Tchr_ID)) THEN
		Begin
			IF (Select not exists (Select *
									From `study`
                                    Where ID = studies 
											AND CBS_ID = ClassBySub_ID)) Then
			Begin
				Insert `study` (ID, Time_Begin, Time_End, Date_Study, Tchr_ID, CBS_ID) Values
                (studies, Begins, Finish, onDate, teacher_ID, ClassBySub_ID);
                
                insert `writelog` (Activities, onCreated) Values
                (concat("Giáo viên ", teacher_ID, " đã thêm buổi học thứ ", studies, " ở lớp ", ClassBySub_ID, " vào lúc: ", Begins," , kết thúc: ", Finish, " ngày: ", onDate), current_timestamp());
                
               Select row_count();
                commit;
            End;
            elseif (Select exists (Select *
									From `study`
                                    Where ID = studies 
											AND CBS_ID = ClassBySub_ID)) THEN
            Begin
				Update `study`
                Set Time_Begin = Begins,
					Time_End = Finish,
                    Date_Study = onDate
				Where studies = ID
						AND ClassBySub_ID = CBS_ID;
			
                Insert `writelog` (Activities, onCreated) Values
                (concat("Giáo viên đã sửa giờ học và giờ kết thúc của lớp ", ClassBySub_ID, " ở buổi ", studies), current_timestamp());
                
                Select row_count();
                commit;
            End;
            else
            Begin
				Select row_count();
                rollback;
            End;
            End if;
        End;
        Else
        Begin
			Select row_count();
            rollback;
        End;
        End IF;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
								- Buổi học ID- Start - Finish - Ngày - 	  		GV ID - Mã lớp theo môn
call myclassroombiden.sp_ins_updStudy(2, 		'7:00', '8:40', '2021-10-11', 'GV2', 'TI098_HK1_CQ02_2021');
-- Lưu ý: Tạo thêm mini form khi click vào form sửa, và lấy đc buổi học ID và mà lớp để sửa giờ bắt đầu, kết thúc, ngày
*/

-- Tạo proc cho giáo viên xoá một buổi học trong study
DELIMITER $$
drop procedure if exists `sp_deleteStudy` $$
create procedure `sp_deleteStudy` (	teacher_ID char(10),
									studies int,
									ClassBySub_ID char(30))
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
    start transaction;
    set autocommit = 0;
    Begin
		IF (Select exists (Select *
							From `study`
                            Where ClassBySub_ID = CBS_ID
									AND studies = ID)) THEN
		Begin
			Delete From `study`
            Where teacher_ID = Tchr_ID
					AND studies = ID
                    AND ClassBySub_ID = CBS_ID;
			
            Insert `writelog` (Activities, onCreated) Values
            (concat("Giáo viên ", teacher_ID, " đã xoá buổi học thứ ", studies, " ở lớp ", ClassBySub_ID), current_timestamp());
            
            Select row_count();
            commit;
        End;
        Else
        Begin
			Select row_count();
            rollback;
        End;
        End IF;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
									- GV ID - Buổi học - Mã lớp theo môn
call myclassroombiden.sp_deleteStudy('GV2', 	2, 		'TI098_HK1_CQ02_2021');
*/

-- tạo proc điểm danh ở phổ thông
DELIMITER $$
Drop procedure if exists `sp_ins_updAttendance_hs` $$
Create procedure `sp_ins_updAttendance_hs` (Teacher_ID char(10),
											Student_ID char(10),
											ClassBySub_ID char(30),
											Attendance_State nvarchar(15))
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
    start transaction;
    set autocommit = 0;
    Begin
    -- Xem Id của giáo viên đó có tồn tại hay k
		IF (Select exists ( Select Tchr_ID
							From `teacher_login`
                            Where Teacher_ID = Tchr_ID
									AND Tchr_Type = 1)) Then
		Begin
        -- Kiểm tra ID của học sinh có tồn tại hay k
			Set @max_ID = (Select max(ID) From `study` Where CBS_ID = ClassBySub_ID);
            IF(Select not exists (Select * From `study_status_hs` Where @max_ID = SSHS_ID
																		AND SSHS_CBS_ID = ClassBySub_ID
                                                                        AND SSHS_STUD_ID = Student_ID)) THEN
            Begin
				Insert `study_status_hs` (SSHS_STUD_ID, SSHS_STUD_Name, SSHS_CBS_ID, SSHS_ID, Time_In, SSHS_Date, Roll_call) Values
				(Student_ID, (Select STUD_Name From `student_info_hs` where Student_ID = STUD_ID), ClassBySub_ID,
				(Select max(ID) From `study` Where CBS_ID = ClassBySub_ID), current_time(), current_date(), Attendance_State);
				
				Select row_count();
				commit;
			End;
            ElseIF (Select exists (Select * From `study_status_hs` Where @max_ID = SSHS_ID
																	AND SSHS_CBS_ID = ClassBySub_ID
																	AND SSHS_STUD_ID = Student_ID)) THEN
			Begin
				Update `study_status_hs`
				Set Time_In = current_time(),
					SSHS_Date = current_date(),
					Roll_call = Attendance_State
				Where SSHS_STUD_ID = Student_ID
						AND SSHS_CBS_ID = ClassBySub_ID
						AND SSHS_ID = @max_ID;
				Select row_count();
				commit;
			End;
			Else
			Begin
				Select row_count();
				rollback;
			End;
			End if;
        End;
        Else
        Begin
			Select row_count();
            rollback;
        End;
        End if;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
											GV ID - HS ID - Mã lớp theo môn - 		Tình trạng
call myclassroombiden.sp_ins_updAttendance_hs('GV4', 'HS1', 'Van_Lop12_a4_2021_2022', 'Vắng');
-- Chỗ tình trạng để radio button
*/

-- tạo proc điểm danh ở đại học
DELIMITER $$
Drop procedure if exists `sp_ins_updAttendance_uni` $$
Create procedure `sp_ins_updAttendance_uni` (Teacher_ID char(10),
											Student_ID char(10),
											ClassBySub_ID char(30),
											Attendance_State nvarchar(15))
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
    start transaction;
    set autocommit = 0;
    Begin
    -- Xem Id của giáo viên đó có tồn tại hay k
		IF (Select exists ( Select Tchr_ID
							From `teacher_login`
                            Where Teacher_ID = Tchr_ID
									AND Tchr_Type = 2)) Then
		Begin
        -- Kiểm tra ID của học sinh có tồn tại hay k
			Set @max_ID = (Select max(ID) From `study` Where CBS_ID = ClassBySub_ID);
            IF (Select not exists (Select * From `study_status_uni` Where @max_ID = SSU_ID
																		AND SSU_CBS_ID = ClassBySub_ID
																		AND SSU_STUD_ID = Student_ID)) THEN
            Begin
				Insert `study_status_uni` (SSU_STUD_ID, SSU_STUD_Name, SSU_CBS_ID, SSU_ID, Time_In, SSU_Date, Roll_call) Values
				(Student_ID, (Select STUD_Name From `student_info_uni` where Student_ID = STUD_ID), ClassBySub_ID,
				(Select max(ID) From `study` Where CBS_ID = ClassBySub_ID), current_time(), current_date(), Attendance_State);
				
				Select row_count();
				commit;
			End;
			ElseIF (Select exists (Select * From `study_status_uni` Where @max_ID = SSU_ID
																	AND SSU_CBS_ID = ClassBySub_ID
																	AND SSU_STUD_ID = Student_ID)) THEN
			Begin
				Update `study_status_uni`
				Set Time_In = current_time(),
					SSU_Date = current_date(),
					Roll_call = Attendance_State
				Where SSU_STUD_ID = Student_ID
						AND SSU_CBS_ID = ClassBySub_ID
						AND SSU_ID = @max_ID;
				Select row_count();
				commit;
			End;
			Else
			Begin
				Select row_count();
				rollback;
			End;
			End if;
        End;
        Else
        Begin
			Select row_count();
            rollback;
        End;
        End if;
    End;
End$$
DELIMITER ;

/*
	**** CODE MẪU ****
											GV ID - HS ID - Mã lớp theo môn - 	Tình trạng
call myclassroombiden.sp_ins_updAttendance_uni('GV2', 'SV1', 'TI098_HK1_CQ02_2021', 'Vắng');
-- Chỗ tình trạng để radio button
*/

-- Tạo procedure để lấy view điểm danh cho phổ thông
DELIMITER $$
Drop procedure if exists `sp_viewAttendance_hs` $$
Create procedure `sp_viewAttendance_hs` (ClassBySub_ID char(30))
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
	Begin
		Set @max_ID = (Select max(ID) From `study` Where CBS_ID = ClassBySub_ID);
		Select distinct 
				SICH.SIC_STUD_ID AS 'Mã HS', 
				SICH.SIC_STUD_Name AS 'Tên HS', 
				SICH.SIC_CBS_ID  AS 'Mã lớp theo môn', 
				case
					when @max_ID = (Select max(SSHS_ID) From `study_status_hs` Where SSHS_CBS_ID = ClassBySub_ID)
					then ifnull(SSH.Roll_call, N'Chưa điểm danh')
					else N'Chưa điểm danh'
				End as 'Tình Trạng'
        From `students_in_class_hs` SICH left join (`study_status_hs` SSH)
				on (SICH.SIC_STUD_ID = SSH.SSHS_STUD_ID)
		Where SICH.SIC_CBS_ID = ClassBySub_ID
        Group by SICH.SIC_STUD_ID;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
											Mã lớp theo môn
call myclassroombiden.sp_viewAttendance_hs('Van_Lop12_a4_2021_2022');
*/

-- Tạo procedure để lấy view điểm danh cho phổ thông
DELIMITER $$
Drop procedure if exists `sp_viewAttendance_uni` $$
Create procedure `sp_viewAttendance_uni` (ClassBySub_ID char(30))
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
	Begin
		Set @max_ID = (Select max(ID) From `study` Where CBS_ID = ClassBySub_ID);
		Select distinct 
				SICU.SIC_STUD_ID AS 'Mã HS', 
				SICU.SIC_STUD_Name AS 'Tên HS', 
				SICU.SIC_CBS_ID  AS 'Mã lớp theo môn', 
				case
					when @max_ID = (Select max(SSU_ID) From `study_status_uni` Where SSU_CBS_ID = ClassBySub_ID)
					then ifnull(SSU.Roll_call, N'Chưa điểm danh')
					else N'Chưa điểm danh'
				End as 'Tình Trạng'
        From `students_in_class_uni` SICU left join (`study_status_uni` SSU)
				on (SICU.SIC_STUD_ID = SSU.SSU_STUD_ID)
		Where SICU.SIC_CBS_ID = ClassBySub_ID
        Group by SICU.SIC_STUD_ID;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
											Mã lớp theo môn
call myclassroombiden.sp_viewAttendance_uni('TI098_HK1_CQ02_2021');
*/

-- Tạo function để điếm số lần có điểm trong điểm chi tiết của học sinh sinh viên
DELIMITER $$
drop function if exists `fn_countStudLower6InDetailMark`$$
Create function `fn_countStudLower6InDetailMark` (	student_ID char(10),
													ClassBySub_ID char(30),
                                                    semester tinyint(1))
Returns int DETERMINISTIC 
Begin
	declare countStud INT;
	set countStud = 0;
	IF (Select exists ( Select * 
						From `detail_mark_hs` 
						Where DMHS_CBS_ID = ClassBySub_ID
								AND DMHS_STUD_ID = student_ID
                                AND DMHS_Semester = semester)) THEN
	Begin
		Select count(DMHS_STUD_ID) into countStud
		From `detail_mark_hs`
		Where DMHS_CBS_ID = ClassBySub_ID
				AND DMHS_STUD_ID = student_ID
                AND DMHS_Semester = 2;
	End;
    End if;
	IF (Select exists ( Select * 
							From `detail_mark_hs` 
							Where DMHS_CBS_ID = ClassBySub_ID
									AND DMHS_STUD_ID = student_ID
									AND DMHS_Semester = semester)) THEN
	Begin
		Select count(DMHS_STUD_ID) into countStud
		From `detail_mark_hs`
		Where DMHS_CBS_ID = ClassBySub_ID
				AND DMHS_STUD_ID = student_ID
                AND DMHS_Semester = 1;
	End;   
	end if;     
    
    return countStud;
End$$
DELIMITER ;
Select `fn_countStudLower6InDetailMark` ('HS1', 'Van_Lop12_a4_2021_2022', 2)

-- Tạo proc để giáo viên thêm chi tiết của học sinh
DELIMITER $$
Drop procedure if exists `sp_insDetailMarks_hs` $$
Create procedure `sp_insDetailMarks_hs`(teacher_ID char(10),
										student_ID char(10),
										ClassBySub_ID char(30),
										exam_type varchar(15),
										mark decimal(4,2),
										semester tinyint(1))
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
	start transaction;
    set autocommit = 0;
    Begin
		IF(Select exists (Select * 
							From `students_in_class_hs`
                            Where SIC_STUD_ID = student_ID
									AND SIC_CBS_ID = ClassBySub_ID)) THEN
        Begin
			IF ((Select `fn_countStudLower6InDetailMark`(student_ID, ClassBySub_ID,semester) < 6)
				AND semester = 2) THEN
			Begin
				insert `detail_mark_hs` (DMHS_STUD_ID, DMHS_CBS_ID, DMHS_Type, DMHS_Mark, DMHS_Semester) Values
				(student_ID, ClassBySub_ID, exam_type, mark, semester);
				
				insert `writelog` (Activities, onCreated) Values
				(concat(teacher_ID, N' đã tạo điểm cho học sinh ', student_ID, N' với loại kiểm tra ', exam_type , N'học kì ', semester, N' với số điểm: ', mark), current_timestamp());
				
				
				Select row_count();
				commit;
			End;
			ElseIF ((Select `fn_countStudLower6InDetailMark`(student_ID, ClassBySub_ID,semester) < 6)
					AND semester = 1) THEN
			Begin
				insert `detail_mark_hs` (DMHS_STUD_ID, DMHS_CBS_ID, DMHS_Type, DMHS_Mark, DMHS_Semester) Values
				(student_ID, ClassBySub_ID, exam_type, mark, semester);
				
				insert `writelog` (Activities, onCreated) Values
				(concat(teacher_ID, N' đã tạo điểm cho học sinh ', student_ID, N' với loại kiểm tra ', exam_type , N'học kì ', semester, N' với số điểm: ', mark), current_timestamp());
				
				
				Select row_count();
				commit;
			End;
			Else
			Begin
				Select row_count();
				rollback;
			End;
			End IF;
		End;
        else
        Begin
			Select row_count();
            rollback;
        End;
        End if;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
											GV ID - HS ID - Mã lớp theo môn - 	Kiểu điểm - 		Điểm - học kì
call myclassroombiden.sp_insDetailMarks_hs('GV4', 'HS1', 'Van_Lop12_a4_2021_2022', 'Thường xuyên', 	9, 		1);
*/

-- Tạo function để lấy số lần điểm danh r cộng điểm cho học sinh
DELIMITER $$
Drop function if exists `fn_countAttendance` $$
Create function `fn_countAttendance` (	student_ID char(10),
										ClassBySub_ID char(30))
Returns Decimal(3,2) DETERMINISTIC
Begin
	declare countAtt INT;
    declare bonusMark decimal(3,2);
	declare getStudies INT;
    
    IF(Select exists (Select STUD_ID
						From `student_info_hs`
                        Where STUD_ID = student_ID)) THEN
	Begin
		-- Lấy số buổi học của lớp học theo môn đó
		select CBS_Studies into getStudies
		From `class_by_subject`
		Where CBS_ID = ClassBySub_ID;
		-- Lấy số buổi có mặt của học sinh đó
		Select ifnull(	(Select count(*) 
						From `study_status_hs`
						Where SSHS_STUD_ID = student_ID
								AND SSHS_CBS_ID = ClassBySub_ID),0) into countAtt;
		-- Cộng thêm điểm vào mỗi học kì đủ điều kiện
		IF (countAtt >= getStudies - 1) THEN
			set bonusMark = 0.25;
		else
			set bonusMark = 0;
		End if;
    End;
    Else
    Begin
		-- Lấy số buổi học của lớp học theo môn đó
		select CBS_Studies into getStudies
		From `class_by_subject`
		Where CBS_ID = ClassBySub_ID;
		-- Lấy số buổi có mặt của học sinh đó
		Select ifnull(	(Select count(*) 
						From `study_status_uni`
						Where SSU_STUD_ID = student_ID
								AND SSU_CBS_ID = ClassBySub_ID),0) into countAtt;
		-- Cộng thêm điểm vào mỗi học kì đủ điều kiện
		set bonusMark = countAtt / getStudies;
    End;
    End if;
    return bonusMark;
End$$
DELIMITER ;


-- Tạo trigger để add điểm học sinh đó vào điểm tông - marks_hs
DELIMITER $$
Drop trigger if exists `trg_insMarks_hs` $$
Create trigger `trg_insMarks_hs`
	AFTER insert 
    ON `detail_mark_hs`	FOR each row
begin
	IF ((Select DMHS_Semester 
		From `detail_mark_hs` 
        Order by DMHS_ID desc
        LIMIT 0,1) = 1) THEN
	Begin
		declare sumMark_Reg decimal(4,2);
		declare countMark_Reg int;
		declare semi_Semester decimal(4,2);
		declare final_Semester decimal(4,2);
		
		-- Lấy tổng điểm kiểm tra thường xuyên của học sinh
		Select ifnull(SUM(DMHS_Mark),0) into sumMark_Reg
		From `detail_mark_hs`
		Where New.DMHS_STUD_ID = DMHS_STUD_ID
				AND New.DMHS_CBS_ID = DMHS_CBS_ID
				AND DMHS_Type = N'Thường xuyên'
                AND DMHS_Semester = 1;
				
		-- Lấy số lần kiểm tra thường xuyên của học sinh
		Select count(*) into countMark_Reg
		From `detail_mark_hs`
		Where New.DMHS_STUD_ID = DMHS_STUD_ID
				AND New.DMHS_CBS_ID = DMHS_CBS_ID
				AND DMHS_Type = N'Thường xuyên'
				AND DMHS_Semester = 1;
		
		-- Lấy điểm kiểm tra giữa kì của học sinh
		Select ifnull(( Select DMHS_Mark
						From `detail_mark_hs`
						where New.DMHS_STUD_ID = DMHS_STUD_ID
								AND New.DMHS_CBS_ID = DMHS_CBS_ID
								AND DMHS_Type = N'Giữa kì'
								AND DMHS_Semester = 1
						Order by DMHS_ID desc
						LIMIT 0,1),0) into semi_Semester;
				
		-- Lấy điểm kiểm tra cuối kì của học sinh
		Select ifnull((	Select DMHS_Mark 
						From `detail_mark_hs`
						where New.DMHS_STUD_ID = DMHS_STUD_ID
								AND New.DMHS_CBS_ID = DMHS_CBS_ID
								AND DMHS_Type = N'Cuối kì'
								AND DMHS_Semester = 1
						Order by DMHS_ID desc
						LIMIT 0,1),0) into final_Semester;
						
		update `marks_hs`
		Set MHS_Semi_Mark = ((sumMark_Reg + (2 * semi_Semester) + (3 * final_Semester)) / (countMark_Reg + 5))
		Where New.DMHS_STUD_ID = MHS_STUD_ID
				AND New.DMHS_CBS_ID = MHS_CBS_ID;
                
		-- Update điểm tổng kết
		update `marks_hs`
		Set MHS_GPA = (MHS_Semi_Mark + (2 * MHS_Final_Mark)) / 3
		Where New.DMHS_STUD_ID = MHS_STUD_ID
				AND New.DMHS_CBS_ID = MHS_CBS_ID;
	End;
    ElseIF ((Select DMHS_Semester 
			From `detail_mark_hs` 
			Order by DMHS_ID desc
			LIMIT 0,1) = 2) THEN
	Begin
		declare sumMark_Reg decimal(4,2);
		declare countMark_Reg int;
		declare semi_Semester decimal(4,2);
		declare final_Semester decimal(4,2);
		
		-- Lấy tổng điểm kiểm tra thường xuyên của học sinh
		Select ifnull(SUM(DMHS_Mark),0) into sumMark_Reg
		From `detail_mark_hs`
		Where New.DMHS_STUD_ID = DMHS_STUD_ID
				AND New.DMHS_CBS_ID = DMHS_CBS_ID
				AND DMHS_Type = N'Thường xuyên'
                AND DMHS_Semester = 2;
				
		-- Lấy số lần kiểm tra thường xuyên của học sinh
		Select count(*) into countMark_Reg
		From `detail_mark_hs`
		Where New.DMHS_STUD_ID = DMHS_STUD_ID
				AND New.DMHS_CBS_ID = DMHS_CBS_ID
				AND DMHS_Type = N'Thường xuyên'
				AND DMHS_Semester = 2;
	
		-- Lấy điểm kiểm tra giữa kì của học sinh
		Select ifnull(( Select DMHS_Mark
						From `detail_mark_hs`
						where New.DMHS_STUD_ID = DMHS_STUD_ID
								AND New.DMHS_CBS_ID = DMHS_CBS_ID
								AND DMHS_Type = N'Giữa kì'
								AND DMHS_Semester = 2
						Order by DMHS_ID desc
						LIMIT 0,1),0) into semi_Semester;
				
		-- Lấy điểm kiểm tra cuối kì của học sinh
		Select ifnull((	Select DMHS_Mark 
						From `detail_mark_hs`
						where New.DMHS_STUD_ID = DMHS_STUD_ID
								AND New.DMHS_CBS_ID = DMHS_CBS_ID
								AND DMHS_Type = N'Cuối kì'
								AND DMHS_Semester = 2
						Order by DMHS_ID desc
						LIMIT 0,1),0) into final_Semester;
						
		update `marks_hs`
		Set MHS_Final_Mark = ((sumMark_Reg + (2 * semi_Semester) + (3 * final_Semester)) / (countMark_Reg + 5))
		Where New.DMHS_STUD_ID = MHS_STUD_ID
				AND New.DMHS_CBS_ID = MHS_CBS_ID;
		
        -- Update điểm tổng kết
		update `marks_hs`
		Set MHS_GPA = (MHS_Semi_Mark + (2 * MHS_Final_Mark)) / 3
		Where New.DMHS_STUD_ID = MHS_STUD_ID
				AND New.DMHS_CBS_ID = MHS_CBS_ID;
	End;
    End if;
end$$
DELIMITER ;

-- Tạo proc để xoá 1 điểm trong bảng điểm chi tiết -Detail_Mark_hs, của học sinh
DELIMITER $$
Drop procedure if exists `sp_deleteDetailMark_hs` $$
Create procedure `sp_deleteDetailMark_hs` (teacher_ID char(10),
											ID int)
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
	start transaction;
    set autocommit = 0;
    Begin
		declare sumMark_Reg decimal(4,2);
		declare countMark_Reg int;
		declare semi_Semester decimal(4,2);
		declare final_Semester decimal(4,2);
        
        Set @STUD_ID = (Select DMHS_STUD_ID From `detail_mark_hs` Where DMHS_ID = ID);
        Set @CBS_ID = (Select DMHS_CBS_ID From `detail_mark_hs` Where DMHS_ID = ID);
        
        IF ((Select DMHS_Semester From `detail_mark_hs` Where DMHS_ID = ID) = 1) THEN
        Begin
			delete from `detail_mark_hs`
            where DMHS_ID = ID;
            
            Select ifnull(SUM(DMHS_Mark),0) into sumMark_Reg
			From `detail_mark_hs`
			Where (Select @STUD_ID) = DMHS_STUD_ID
					AND (Select @CBS_ID)= DMHS_CBS_ID
					AND DMHS_Type = N'Thường xuyên'
					AND DMHS_Semester = 1;
					
			-- Lấy số lần kiểm tra thường xuyên của học sinh
			Select count(*) into countMark_Reg
			From `detail_mark_hs`
			Where (Select @STUD_ID) = DMHS_STUD_ID
					AND (Select @CBS_ID) = DMHS_CBS_ID
					AND DMHS_Type = N'Thường xuyên'
					AND DMHS_Semester = 1;
			
			-- Lấy điểm kiểm tra giữa kì của học sinh
			Select ifnull(( Select DMHS_Mark
							From `detail_mark_hs`
							where (Select @STUD_ID) = DMHS_STUD_ID
									AND (Select @CBS_ID) = DMHS_CBS_ID
									AND DMHS_Type = N'Giữa kì'
									AND DMHS_Semester = 1
							Order by DMHS_ID desc
							LIMIT 0,1),0) into semi_Semester;
					
			-- Lấy điểm kiểm tra cuối kì của học sinh
			Select ifnull((	Select DMHS_Mark 
							From `detail_mark_hs`
							where (Select @STUD_ID) = DMHS_STUD_ID
									AND (Select @CBS_ID) = DMHS_CBS_ID
									AND DMHS_Type = N'Cuối kì'
									AND DMHS_Semester = 1
							Order by DMHS_ID desc
							LIMIT 0,1),0) into final_Semester;
							
			update `marks_hs`
			Set MHS_Semi_Mark = ((sumMark_Reg + (2 * semi_Semester) + (3 * final_Semester)) / (countMark_Reg + 5))
			Where (Select @STUD_ID) = MHS_STUD_ID
					AND (Select @CBS_ID) = MHS_CBS_ID;
                    
			-- Update điểm tổng kết
			update `marks_hs`
            Set MHS_GPA = (MHS_Semi_Mark + (2 * MHS_Final_Mark)) / 3
            Where (Select @STUD_ID) = MHS_STUD_ID
					AND (Select @CBS_ID) = MHS_CBS_ID;
			
            insert `writelog` (Activities, onCreated) Values
            (concat(teacher_ID, N' đã xoá 1 điểm ở học kì 1 của học sinh ', (Select @STUD_ID), ' lớp ', (Select @CBS_ID)), current_timestamp());
            
            Select row_count();
			commit;
			End;
		elseif ((Select DMHS_Semester From `detail_mark_hs` Where DMHS_ID = ID) = 2) THEN
        Begin
			delete from `detail_mark_hs`
            where DMHS_ID = ID;
            
			-- Lấy tổng điểm kiểm tra thường xuyên của học sinh
			Select ifnull(SUM(DMHS_Mark),0) into sumMark_Reg
			From `detail_mark_hs`
			Where (Select @STUD_ID) = DMHS_STUD_ID
					AND (Select @CBS_ID) = DMHS_CBS_ID
					AND DMHS_Type = N'Thường xuyên'
					AND DMHS_Semester = 2;
					
			-- Lấy số lần kiểm tra thường xuyên của học sinh
			Select count(*) into countMark_Reg
			From `detail_mark_hs`
			Where (Select @STUD_ID) = DMHS_STUD_ID
					AND (Select @CBS_ID) = DMHS_CBS_ID
					AND DMHS_Type = N'Thường xuyên'
					AND DMHS_Semester = 2;
		
			-- Lấy điểm kiểm tra giữa kì của học sinh
			Select ifnull(( Select DMHS_Mark
							From `detail_mark_hs`
							where (Select @STUD_ID) = DMHS_STUD_ID
									AND (Select @CBS_ID) = DMHS_CBS_ID
									AND DMHS_Type = N'Giữa kì'
									AND DMHS_Semester = 2
							Order by DMHS_ID desc
							LIMIT 0,1),0) into semi_Semester;
					
			-- Lấy điểm kiểm tra cuối kì của học sinh
			Select ifnull((	Select DMHS_Mark 
							From `detail_mark_hs`
							where (Select @STUD_ID) = DMHS_STUD_ID
									AND (Select @CBS_ID) = DMHS_CBS_ID
									AND DMHS_Type = N'Cuối kì'
									AND DMHS_Semester = 2
							Order by DMHS_ID desc
							LIMIT 0,1),0) into final_Semester;
							
			update `marks_hs`
			Set MHS_Final_Mark = ((sumMark_Reg + (2 * semi_Semester) + (3 * final_Semester)) / (countMark_Reg + 5))
			Where (Select @STUD_ID) = MHS_STUD_ID
					AND (Select @CBS_ID) = MHS_CBS_ID;
                    
			-- Update điểm tổng kết
			update `marks_hs`
            Set MHS_GPA = (MHS_Semi_Mark + (2 * MHS_Final_Mark)) / 3
            Where (Select @STUD_ID) = MHS_STUD_ID
					AND (Select @CBS_ID) = MHS_CBS_ID;
                    
			insert `writelog` (Activities, onCreated) Values
            (concat(teacher_ID, N' đã xoá 1 điểm ở học kì 2 của học sinh ', (Select @STUD_ID), ' lớp ', (Select @CBS_ID)), current_timestamp());

			Select row_count();
			commit;
        End;
        else
        Begin
			Select row_count();
            rollback;
        End;
        End if;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
											GV ID - DetailMark_HS_ID
call myclassroombiden.sp_deleteDetailMark_hs('GV3', 	58);
*/

-- Tạo proc để update 1 điểm số của học sinh
DELIMITER $$
Drop procedure if exists `sp_updateDetailMark_hs` $$
Create procedure `sp_updateDetailMark_hs` (teacher_ID char(10),
											ID int,
                                            type_exam varchar(15),
                                            mark decimal(4,2),
                                            semester int)
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
	start transaction;
    set autocommit = 0;
    Begin
		declare sumMark_Reg decimal(4,2);
		declare countMark_Reg int;
		declare semi_Semester decimal(4,2);
		declare final_Semester decimal(4,2);
        
        Set @STUD_ID = (Select DMHS_STUD_ID From `detail_mark_hs` Where DMHS_ID = ID);
        Set @CBS_ID = (Select DMHS_CBS_ID From `detail_mark_hs` Where DMHS_ID = ID);
        
        IF ((Select DMHS_Semester From `detail_mark_hs` Where DMHS_ID = ID) = 1) THEN
        Begin
			Update `detail_mark_hs`
            Set DMHS_Type = type_exam,
				DMHS_Mark = mark,
                DMHS_Semester = semester
			Where DMHS_ID = ID;
            
            -- Lấy tổng điểm của thường xuyên
            Select ifnull(SUM(DMHS_Mark),0) into sumMark_Reg
			From `detail_mark_hs`
			Where (Select @STUD_ID) = DMHS_STUD_ID
					AND (Select @CBS_ID)= DMHS_CBS_ID
					AND DMHS_Type = N'Thường xuyên'
					AND DMHS_Semester = 1;
					
			-- Lấy số lần kiểm tra thường xuyên của học sinh
			Select count(*) into countMark_Reg
			From `detail_mark_hs`
			Where (Select @STUD_ID) = DMHS_STUD_ID
					AND (Select @CBS_ID) = DMHS_CBS_ID
					AND DMHS_Type = N'Thường xuyên'
					AND DMHS_Semester = 1;
			
			-- Lấy điểm kiểm tra giữa kì của học sinh
			Select ifnull(( Select DMHS_Mark
							From `detail_mark_hs`
							where (Select @STUD_ID) = DMHS_STUD_ID
									AND (Select @CBS_ID) = DMHS_CBS_ID
									AND DMHS_Type = N'Giữa kì'
									AND DMHS_Semester = 1
							Order by DMHS_ID desc
							LIMIT 0,1),0) into semi_Semester;
					
			-- Lấy điểm kiểm tra cuối kì của học sinh
			Select ifnull((	Select DMHS_Mark 
							From `detail_mark_hs`
							where (Select @STUD_ID) = DMHS_STUD_ID
									AND (Select @CBS_ID) = DMHS_CBS_ID
									AND DMHS_Type = N'Cuối kì'
									AND DMHS_Semester = 1
							Order by DMHS_ID desc
							LIMIT 0,1),0) into final_Semester;
							
			update `marks_hs`
			Set MHS_Semi_Mark = ((sumMark_Reg + (2 * semi_Semester) + (3 * final_Semester)) / (countMark_Reg + 5))
			Where (Select @STUD_ID) = MHS_STUD_ID
					AND (Select @CBS_ID) = MHS_CBS_ID;
				
            -- Update điểm tổng kết
			update `marks_hs`
            Set MHS_GPA = (MHS_Semi_Mark + (2 * MHS_Final_Mark)) / 3
            Where (Select @STUD_ID) = MHS_STUD_ID
					AND (Select @CBS_ID) = MHS_CBS_ID;
			
            insert `writelog` (Activities, onCreated) Values
            (concat(teacher_ID, N' đã update 1 điểm ở học kì 1 của học sinh ', (Select @STUD_ID), ' lớp ', (Select @CBS_ID)), current_timestamp());
            
            Select row_count();
			commit;
			End;
		elseif ((Select DMHS_Semester From `detail_mark_hs` Where DMHS_ID = ID) = 2) THEN
        Begin
			Update `detail_mark_hs`
            Set DMHS_Type = type_exam,
				DMHS_Mark = mark,
                DMHS_Semester = semester
			Where DMHS_ID = ID;
            
			-- Lấy tổng điểm kiểm tra thường xuyên của học sinh
			Select ifnull(SUM(DMHS_Mark),0) into sumMark_Reg
			From `detail_mark_hs`
			Where (Select @STUD_ID) = DMHS_STUD_ID
					AND (Select @CBS_ID) = DMHS_CBS_ID
					AND DMHS_Type = N'Thường xuyên'
					AND DMHS_Semester = 2;
					
			-- Lấy số lần kiểm tra thường xuyên của học sinh
			Select count(*) into countMark_Reg
			From `detail_mark_hs`
			Where (Select @STUD_ID) = DMHS_STUD_ID
					AND (Select @CBS_ID) = DMHS_CBS_ID
					AND DMHS_Type = N'Thường xuyên'
					AND DMHS_Semester = 2;
		
			-- Lấy điểm kiểm tra giữa kì của học sinh
			Select ifnull(( Select DMHS_Mark
							From `detail_mark_hs`
							where (Select @STUD_ID) = DMHS_STUD_ID
									AND (Select @CBS_ID) = DMHS_CBS_ID
									AND DMHS_Type = N'Giữa kì'
									AND DMHS_Semester = 2
							Order by DMHS_ID desc
							LIMIT 0,1),0) into semi_Semester;
					
			-- Lấy điểm kiểm tra cuối kì của học sinh
			Select ifnull((	Select DMHS_Mark 
							From `detail_mark_hs`
							where (Select @STUD_ID) = DMHS_STUD_ID
									AND (Select @CBS_ID) = DMHS_CBS_ID
									AND DMHS_Type = N'Cuối kì'
									AND DMHS_Semester = 2
							Order by DMHS_ID desc
							LIMIT 0,1),0) into final_Semester;
							
			update `marks_hs`
			Set MHS_Final_Mark = ((sumMark_Reg + (2 * semi_Semester) + (3 * final_Semester)) / (countMark_Reg + 5))
			Where (Select @STUD_ID) = MHS_STUD_ID
					AND (Select @CBS_ID) = MHS_CBS_ID;
			
            -- Update điểm tổng kết
            update `marks_hs`
            Set MHS_GPA = (MHS_Semi_Mark + (2 * MHS_Final_Mark)) / 3
            Where (Select @STUD_ID) = MHS_STUD_ID
					AND (Select @CBS_ID) = MHS_CBS_ID;
                    
			insert `writelog` (Activities, onCreated) Values
            (concat(teacher_ID, N' đã update 1 điểm ở học kì 2 của học sinh ', (Select @STUD_ID), ' lớp ', (Select @CBS_ID)), current_timestamp());

			Select row_count();
			commit;
        End;
        else
        Begin
			Select row_count();
            rollback;
        End;
        End if;
    End;
End$$
DELIMITER ;
/*
	**** CODE MẪU ****
											GV ID - DetailMark_HS_ID - Type - mark - học kì
call myclassroombiden.sp_updateDetailMark_hs('GV3', 67, 			'Giữa kì', 9, 		1);
*/

-- Tạo proc để set số % điểm từng phần của sinh viên
DELIMTER $$
Drop procedure if exists `sp_insertMarkPercent_uni` $$
Create procedure `sp_insertMarkPercent_uni` ()
DELIMITER ;


-- Tạo proc để giáo viên thêm chi tiết của học sinh
DELIMITER $$
Drop procedure if exists `sp_insDetailMarks_uni` $$
Create procedure `sp_insDetailMarks_uni` (teacher_ID char(10),
											student_ID char(10),
											ClassBySub_ID char(30),
											exam_type varchar(15),
											mark decimal(4,2))
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
	start transaction;
    set autocommit = 0;
    Begin
		IF (Select exists (Select *
							FROM `students_in_class_uni`
                            Where SIC_STUD_ID = student_ID
									AND SIC_CBS_ID = ClassBySub_ID)) THEN
        Begin
			Insert `detail_mark_uni` (DMU_STUD_ID, DMU_CBS_ID, DMU_Type, DMU_Mark) Values
            (student_ID, ClassBySub_ID, exam_type, mark);
            
            Insert `writelog` (Activities, onCreated) Values
            (concat(teacher_ID, N' đã thêm điểm cho sinh viên ', student_ID, N' với loại điểm ', exam_type, N' , điểm: ', mark),current_timestamp());
            
			Select row_count();
            commit;
        End;
        Else
        Begin
			Select row_count();
            rollback;
        End;
        End if;
    End;
End$$
DELIMITER ;
/*
	---- CODE MẪU ----
												GV ID - SV ID - Mã lớp theo môn -	Kiểu điểm - Điểm	
    call myclassroombiden.sp_insDetailMarks_uni('GV2', 'SV1', 'TI099_HK1_CQ03_2021', 'Thực hành', 	  8);
*/

-- Tạo proc để nhập % điểm của từng loại ở đại học
DELIMITER $$
Drop procedure if exists `sp_ins_updMarkPercent` $$
Create procedure `sp_ins_updMarkPercent` (ClassBySub_ID char(30),
											practice_percent int,
                                            exercise_percent int,
                                            semi_semester_percent int)
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
	start transaction;
    set autocommit = 0;
    Begin
		IF (Select exists (Select *
							From `class_by_subject`
                            Where CBS_ID = ClassBySub_ID)) THEN
		Begin
			IF (Select exists (Select *
								From `marks_percent_uni`
								Where MPU_CBS_ID = ClassBySub_ID)) THEN
			Begin
				IF (practice_percent + exercise_percent + semi_semester_percent + 10 = 100) THEN
				Begin
					Update `marks_percent_uni`
					Set MPU_Pratice_Percent = practice_percent,
						MPU_Exercise_Percent = exercise_percent,
						MPU_Semi_Semester_Percent = semi_semester_percent
					Where MPU_CBS_ID = ClassBySub_ID;
					
					Select row_count();
					commit;
				End;
				Else
				Begin
					Select row_count();
					Rollback;
				End;
				End if;
			End;
			Else
			Begin
				IF (practice_percent + exercise_percent + semi_semester_percent + 10 = 100) THEN
				Begin
					insert `marks_percent_uni` (MPU_CBS_ID, MPU_Pratice_Percent, MPU_Exercise_Percent, MPU_Semi_Semester_Percent) Values
					(ClassBySub_ID, practice_percent, exercise_percent, semi_semester_percent);
					 
					Select row_count();
					commit;
				End;
				Else
				Begin
					Select row_count();
					Rollback;
				End;
				End if;
			End;
			End if;
		End;
        Else
        Begin
			Select row_count();
            rollback;
        End;
        End if;
    End;
End$$
DELIMITER ;
/*
	---- CODE MẪU ----
												Mã lớp theo môn  	- % thực hành - % Bài tập - % Giữa kì
    call myclassroombiden.sp_ins_updMarkPercent('TI099_HK1_CQ03_2021', 0, 				40, 		50);
*/

-- Tạo trigger để update điểm bên mark_uni
DELIMITER $$
Drop trigger if exists `trg_insMark_uni` $$
Create trigger `trg_insMark_uni`
	AFTER insert
    ON `detail_mark_uni` FOR EACH ROW
Begin

	-- tạo biến lấy % các thành phần điểm
	declare practice_percent decimal(3,2);
    declare exercise_percent decimal(3,2);
    declare semi_semester_percent decimal(3,2);
    
    -- tạo biến lấy điểm theo mã vừa nhập
    declare attendance_mark decimal(3,2);
    declare practice_mark decimal(4,2);
    declare exercise_mark decimal(4,2);
    declare semi_mark decimal(4,2);
    declare final_mark decimal(4,2);

    
    -- tạo biến để lấy điểm trung bình của tổng thực hành và bài tập và giữa kì
    declare avg_semi_mark decimal(4,2);
    
    -- Lấy số % điểm của thực hành
	Select MPU_Pratice_Percent/100 into practice_percent
    From `marks_percent_uni`
    Where New.DMU_CBS_ID = MPU_CBS_ID;
    
    -- Lấy số % điểm của bài tập
    Select MPU_Exercise_Percent/100 into exercise_percent
    From `marks_percent_uni`
    Where New.DMU_CBS_ID = MPU_CBS_ID;
    
    -- Lấy số % điểm của giữa kì
	Select MPU_Semi_Semester_Percent/100 into semi_semester_percent
    From `marks_percent_uni`
    Where New.DMU_CBS_ID = MPU_CBS_ID;
    
    -- Lấy điểm của điểm danh
    Select ifnull((Select fn_countAttendance(New.DMU_STUD_ID, New.DMU_CBS_ID)),0) into attendance_mark;
    
    -- Lấy điểm của thực hành
    Select ifnull((Select sum(DMU_Mark)/count(DMU_STUD_ID)
					From `detail_mark_uni`
					Where New.DMU_STUD_ID = DMU_STUD_ID
							AND New.DMU_CBS_ID = DMU_CBS_ID
							AND DMU_Type = N'Thực hành'),0) * practice_percent into practice_mark;
	
    -- Lấy điểm của bài tập
    Select ifnull((Select sum(DMU_Mark)/count(DMU_STUD_ID)
					From `detail_mark_uni`
					Where New.DMU_STUD_ID = DMU_STUD_ID
							AND New.DMU_CBS_ID = DMU_CBS_ID
							AND DMU_Type = N'Bài tập'),0) * exercise_percent into exercise_mark;
	
    -- Lấy điểm của giữa kì
    Select ifnull((Select sum(DMU_Mark)/count(DMU_STUD_ID)
					From `detail_mark_uni`
					Where New.DMU_STUD_ID = DMU_STUD_ID
							AND New.DMU_CBS_ID = DMU_CBS_ID
							AND DMU_Type = N'Giữa kì'),0) * semi_semester_percent into semi_mark;
                            
	-- Lấy điểm cuối kì
    Select ifnull((Select DMU_Mark
					From `detail_mark_uni`
					Where New.DMU_STUD_ID = DMU_STUD_ID
							AND New.DMU_CBS_ID = DMU_CBS_ID
							AND DMU_Type = N'Cuối kì'),0) into final_mark;
                            
	-- Update điểm vào marks_uni
    update `marks_uni`
    Set MU_Semi_Mark = (attendance_mark + practice_mark + exercise_mark + semi_mark),
		MU_Final_Mark = final_mark
    Where New.DMU_STUD_ID = MU_STUD_ID
			AND New.DMU_CBS_ID = MU_CBS_ID;
            
	-- Update điểm GPA của sinh viên đó
    update `marks_uni`
    Set MU_GPA = (MU_Semi_Mark + MU_Final_Mark)/2
    Where New.DMU_STUD_ID = MU_STUD_ID
			AND New.DMU_CBS_ID = MU_CBS_ID;
End$$
DELIMITER ;

-- Tạo proc để xoá 1 điểm chi tiết của học sinh theo ID
DELIMITER $$
Drop procedure if exists `sp_deleteDetailMark_uni` $$
Create procedure `sp_deleteDetailMark_uni` (teacher_ID char(10),
											ID int)
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
	start transaction;
    set autocommit = 0;
    Begin
		-- tạo biến lấy % các thành phần điểm
		declare practice_percent decimal(3,2);
		declare exercise_percent decimal(3,2);
		declare semi_semester_percent decimal(3,2);
		
		-- tạo biến lấy điểm theo mã vừa nhập
		declare attendance_mark decimal(3,2);
		declare practice_mark decimal(4,2);
		declare exercise_mark decimal(4,2);
		declare semi_mark decimal(4,2);
		declare final_mark decimal(4,2);
		
		-- tạo biến để lấy điểm trung bình của tổng thực hành và bài tập và giữa kì
		declare avg_semi_mark decimal(4,2);
        
		-- tạo biến để lấy SV ID và Mã lớp theo môn
        Set @getSTUD_ID = (Select DMU_STUD_ID From `detail_mark_uni` Where DMU_ID = ID);
        Set @getCBS_ID = (Select DMU_CBS_ID From `detail_mark_uni` Where DMU_ID = ID);
        
		-- Lấy số % điểm của thực hành
		Select MPU_Pratice_Percent/100 into practice_percent
		From `marks_percent_uni`
		Where (Select @getCBS_ID) = MPU_CBS_ID;
		
		-- Lấy số % điểm của bài tập
		Select MPU_Exercise_Percent/100 into exercise_percent
		From `marks_percent_uni`
		Where (Select @getCBS_ID) = MPU_CBS_ID;
		
		-- Lấy số % điểm của giữa kì
		Select MPU_Semi_Semester_Percent/100 into semi_semester_percent
		From `marks_percent_uni`
		Where (Select @getCBS_ID) = MPU_CBS_ID;
        
         -- Lấy điểm của điểm danh
		Select ifnull((Select fn_countAttendance((Select @getSTUD_ID), (Select @getCBS_ID))),0) into attendance_mark;
		
        -- Nếu có tồn tại thì thực hiện các phép tính bên trong
        IF (Select exists (Select *
							From `detail_mark_uni`
                            Where DMU_ID = ID)) THEN
		Begin
			-- xoá 1 dòng theo ID
            Delete From `detail_mark_uni`
            Where DMU_ID = ID;
            
			-- Lấy điểm của thực hành
			Select ifnull((Select sum(DMU_Mark)/count(DMU_STUD_ID)
							From `detail_mark_uni`
							Where (Select @getSTUD_ID) = DMU_STUD_ID
									AND (Select @getCBS_ID) = DMU_CBS_ID
									AND DMU_Type = N'Thực hành'),0) * practice_percent into practice_mark;
			
			-- Lấy điểm của bài tập
			Select ifnull((Select sum(DMU_Mark)/count(DMU_STUD_ID)
							From `detail_mark_uni`
							Where (Select @getSTUD_ID) = DMU_STUD_ID
									AND (Select @getCBS_ID) = DMU_CBS_ID
									AND DMU_Type = N'Bài tập'),0) * exercise_percent into exercise_mark;
			
			-- Lấy điểm của giữa kì
			Select ifnull((Select sum(DMU_Mark)/count(DMU_STUD_ID)
							From `detail_mark_uni`
							Where (Select @getSTUD_ID) = DMU_STUD_ID
									AND (Select @getCBS_ID) = DMU_CBS_ID
									AND DMU_Type = N'Giữa kì'),0) * semi_semester_percent into semi_mark;
									
			-- Lấy điểm cuối kì
			Select ifnull((Select DMU_Mark
							From `detail_mark_uni`
							Where (Select @getSTUD_ID) = DMU_STUD_ID
									AND (Select @getCBS_ID) = DMU_CBS_ID
									AND DMU_Type = N'Cuối kì'),0) into final_mark;
									
			-- Update điểm vào marks_uni
			update `marks_uni`
			Set MU_Semi_Mark = (attendance_mark + practice_mark + exercise_mark + semi_mark) * 0.5,
				MU_Final_Mark = final_mark
			Where (Select @getSTUD_ID) = MU_STUD_ID
					AND (Select @getCBS_ID)= MU_CBS_ID;
					
			-- Update điểm GPA của sinh viên đó
			update `marks_uni`
			Set MU_GPA = (MU_Semi_Mark + MU_Final_Mark) / 2
			Where (Select @getSTUD_ID) = MU_STUD_ID
					AND (Select @getCBS_ID) = MU_CBS_ID;
			
            insert `writelog` (Activities, onCreated) Values
            (concat(teacher_ID, ' đã xoá một điểm của học sinh ', (Select @getSTUD_ID), ' ở lớp ', (Select @getCBS_ID)), current_timestamp());
            
            Select row_count();
            Commit;
		End;
        Else
        Begin
			Select row_count();
            rollback;
        End;
        End if;
    End;
End$$
DELIMITER ;
/*
	---- CODE MẪU ----
												GV ID - Điểm chi tiết ID
    CALL myclassroombiden.sp_deleteDetailMark_uni(GV2, 		16);
*/

-- Tạo proc để update 1 điểm chi tiết của sinh viên theo ID
DELIMITER $$
Drop procedure if exists `sp_updateDetailMark_uni` $$
Create procedure `sp_updateDetailMark_uni` (teacher_ID char(10),
											ID int,
                                            exam_type varchar(10),
                                            mark decimal(4,2))
Begin
	DECLARE exit handler for SQLEXCEPTION
		BEGIN
			GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
			SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
			SELECT @full_error;
		END;
	start transaction;
    set autocommit = 0;
    Begin
		-- tạo biến lấy % các thành phần điểm
		declare practice_percent decimal(3,2);
		declare exercise_percent decimal(3,2);
		declare semi_semester_percent decimal(3,2);
		
		-- tạo biến lấy điểm theo mã vừa nhập
		declare attendance_mark decimal(3,2);
		declare practice_mark decimal(4,2);
		declare exercise_mark decimal(4,2);
		declare semi_mark decimal(4,2);
		declare final_mark decimal(4,2);
		
		-- tạo biến để lấy điểm trung bình của tổng thực hành và bài tập và giữa kì
		declare avg_semi_mark decimal(4,2);
        
		-- tạo biến để lấy SV ID và Mã lớp theo môn
        Set @getSTUD_ID = (Select DMU_STUD_ID From `detail_mark_uni` Where DMU_ID = ID);
        Set @getCBS_ID = (Select DMU_CBS_ID From `detail_mark_uni` Where DMU_ID = ID);
        
		-- Lấy số % điểm của thực hành
		Select MPU_Pratice_Percent/100 into practice_percent
		From `marks_percent_uni`
		Where (Select @getCBS_ID) = MPU_CBS_ID;
		
		-- Lấy số % điểm của bài tập
		Select MPU_Exercise_Percent/100 into exercise_percent
		From `marks_percent_uni`
		Where (Select @getCBS_ID) = MPU_CBS_ID;
		
		-- Lấy số % điểm của giữa kì
		Select MPU_Semi_Semester_Percent/100 into semi_semester_percent
		From `marks_percent_uni`
		Where (Select @getCBS_ID) = MPU_CBS_ID;
        
         -- Lấy điểm của điểm danh
		Select ifnull((Select fn_countAttendance((Select @getSTUD_ID), (Select @getCBS_ID))),0) into attendance_mark;
		
        -- Nếu có tồn tại thì thực hiện các phép tính bên trong
        IF (Select exists (Select *
							From `detail_mark_uni`
                            Where DMU_ID = ID)) THEN
		Begin
			-- xoá 1 dòng theo ID
            Update `detail_mark_uni`
            Set DMU_Type = exam_type,
				DMU_Mark = mark
			Where DMU_ID = ID;
            
			-- Lấy điểm của thực hành
			Select ifnull((Select sum(DMU_Mark)/count(DMU_STUD_ID)
							From `detail_mark_uni`
							Where (Select @getSTUD_ID) = DMU_STUD_ID
									AND (Select @getCBS_ID) = DMU_CBS_ID
									AND DMU_Type = N'Thực hành'),0) * practice_percent into practice_mark;
			
			-- Lấy điểm của bài tập
			Select ifnull((Select sum(DMU_Mark)/count(DMU_STUD_ID)
							From `detail_mark_uni`
							Where (Select @getSTUD_ID) = DMU_STUD_ID
									AND (Select @getCBS_ID) = DMU_CBS_ID
									AND DMU_Type = N'Bài tập'),0) * exercise_percent into exercise_mark;
			
			-- Lấy điểm của giữa kì
			Select ifnull((Select sum(DMU_Mark)/count(DMU_STUD_ID)
							From `detail_mark_uni`
							Where (Select @getSTUD_ID) = DMU_STUD_ID
									AND (Select @getCBS_ID) = DMU_CBS_ID
									AND DMU_Type = N'Giữa kì'),0) * semi_semester_percent into semi_mark;
									
			-- Lấy điểm cuối kì
			Select ifnull((Select DMU_Mark
							From `detail_mark_uni`
							Where (Select @getSTUD_ID) = DMU_STUD_ID
									AND (Select @getCBS_ID) = DMU_CBS_ID
									AND DMU_Type = N'Cuối kì'),0) into final_mark;
									
			-- Update điểm vào marks_uni
			update `marks_uni`
			Set MU_Semi_Mark = (attendance_mark + practice_mark + exercise_mark + semi_mark) * 0.5,
				MU_Final_Mark = final_mark
			Where (Select @getSTUD_ID) = MU_STUD_ID
					AND (Select @getCBS_ID)= MU_CBS_ID;
					
			-- Update điểm GPA của sinh viên đó
			update `marks_uni`
			Set MU_GPA = (MU_Semi_Mark + MU_Final_Mark) / 2
			Where (Select @getSTUD_ID) = MU_STUD_ID
					AND (Select @getCBS_ID) = MU_CBS_ID;
			
            insert `writelog` (Activities, onCreated) Values
            (concat(teacher_ID, ' đã cập nhật một điểm của học sinh ', (Select @getSTUD_ID), ' ở lớp ', (Select @getCBS_ID)), current_timestamp());
            
			Select row_count();
            Commit;
		End;
        Else
        Begin
			Select row_count();
            rollback;
        End;
        End if;
    End;
End$$
DELIMITER ;
/*
	---- CODE MẪU ----
												 GV ID - Điểm chi tiết ID - Kiểu điểm - Điểm
    call myclassroombiden.sp_updateDetailMark_uni('GV2', 		18, 		'Cuối kì', 	6);

*/


