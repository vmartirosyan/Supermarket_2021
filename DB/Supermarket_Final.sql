CREATE TABLE address_location(
	id INT PRIMARY KEY IDENTITY,
    city NVARCHAR(25), 
    district NVARCHAR(25),
    street NVARCHAR(25),
	apartment NVARCHAR(25),
    building_number INT,
    postal_code INT,
)
CREATE TABLE branch(
    id INT PRIMARY KEY IDENTITY,
    location_id INT FOREIGN KEY REFERENCES address_location(id),
    frezer_volume INT,
	storage_volume INT,
    [type] VARCHAR(25)
)​

CREATE TABLE departments(
	id INT PRIMARY KEY IDENTITY,
	[name] NVARCHAR(30),
)
CREATE TABLE category(
	id INT PRIMARY KEY IDENTITY,
	department_id INT FOREIGN KEY REFERENCES departments(id),
	[description] NVARCHAR(250)
)​
CREATE TABLE supplier(
   id INT PRIMARY KEY IDENTITY,
   name NVARCHAR(25),
   location_id INT FOREIGN KEY REFERENCES address_location(id),
   contract_exp_date DATE,
   contact_num INT,
   contact_email NVARCHAR(25) 
)
CREATE TABLE product(
	id INT PRIMARY KEY IDENTITY,
	[name] NVARCHAR(50) not null,
	[description] NVARCHAR(500),
	price money check(price > 0),
	cost money check(cost > 0),
	code INT,
	volume INT,
	refunded bit,
	supplier_id INT FOREIGN KEY REFERENCES supplier(id),
	category_id INT FOREIGN KEY REFERENCES category(id),
)

​​
CREATE TABLE users(
    id INT PRIMARY KEY IDENTITY,
	email NVARCHAR(64),
    username CHAR(20),
	passwd CHAR(64),
)
​
CREATE TABLE log_sessions(
	id INT PRIMARY KEY IDENTITY,
    [user_id] INT FOREIGN KEY REFERENCES users(id),
    log_in DATETIME,
	log_out DATETIME,
)
​
CREATE TABLE customer(
	[user_id] INT FOREIGN KEY REFERENCES users(id),
	first_name NVARCHAR(30),
	last_name NVARCHAR(30),
	birth_date DATE,
	gender NVARCHAR (50),
	phone_number CHAR(12),
	address_id INT FOREIGN KEY REFERENCES address_location(id),
	created_date DATETIME,
	PRIMARY KEY([user_id])
)
​
CREATE TABLE proffesion(
   id INT PRIMARY KEY IDENTITY,
   prof_name NVARCHAR (50),
)
​
CREATE TABLE employee(
	id INT PRIMARY KEY IDENTITY,
	[users_id] INT FOREIGN KEY REFERENCES users(id),
	first_name NVARCHAR(50),
    last_name NVARCHAR(50),
	birth_date DATE, 
	gender NVARCHAR (50),
	phone_number char (12),
	address_id INT FOREIGN KEY REFERENCES address_location(id),
	profession_id INT FOREIGN KEY REFERENCES proffesion(id),
	starting_salary money,
    salary money,
	firstday_date date,
	created_date datetime,
	department_id INT FOREIGN key REFERENCES departments(id),
	branch_id INT foreign key REFERENCES branch(id),
)
​
​
CREATE TABLE deliveryman(
	employee_id INT FOREIGN KEY REFERENCES users(id),
	car_type NVARCHAR(20),
	car_number NVARCHAR(7),
	car_model NVARCHAR(15),
	PRIMARY KEY(employee_id)
)
​
CREATE TABLE wish_list(
	product_id INT FOREIGN KEY REFERENCES product(ID),
	customer_id INT FOREIGN KEY REFERENCES users(ID), 
	PRIMARY KEY(product_id,customer_id)
)
​
​
​
CREATE TABLE order_status(
    id INT  PRIMARY KEY IDENTITY,
	[name] NVARCHAR(8)
);
​
CREATE TABLE delivery_status(
    id INT  PRIMARY KEY IDENTITY,
	[name] VARCHAR(11)
);
​
​
--INSERT INTO order_status(name) VALUES('Approved');
--INSERT INTO order_status(name) VALUES('Pending');
--INSERT INTO order_status(name) VALUES('Canceled')
--INSERT INTO order_status(name) VALUES('Busket')
​
CREATE TABLE [order](
	id INT PRIMARY KEY IDENTITY,
	customer_id INT FOREIGN KEY REFERENCES users(id),
	delivery_status_id INT FOREIGN KEY REFERENCES delivery_status(id),
	order_status_id INT FOREIGN KEY REFERENCES order_status(id),
	delivery_man_id INT FOREIGN KEY REFERENCES users(id),
	order_description VARCHAR(255),
	branch_id INT FOREIGN KEY REFERENCES branch(id),
	peyment_status BIT DEFAULT 0,
	created_at datetime, 
	delivered datetime,
)
​
CREATE TABLE order_product(
	order_id INT FOREIGN KEY REFERENCES [order](ID),
	product_id INT FOREIGN KEY REFERENCES product(id),
	quantity INT,
	PRIMARY KEY (order_id, product_id)
)
​
--------------------------------------------------------------------------------
​
CREATE TABLE cashbox(
	id INT PRIMARY KEY IDENTITY,
	branch_id INT foreign key REFERENCES branch(id),
	[money] money check([money]>0), 
)
​
CREATE TABLE cashbox_transaction(
	id INT PRIMARY KEY IDENTITY,
	cashier INT foreign key REFERENCES employee(id),
	cashbox_id INT foreign key REFERENCES cashbox(id),
	[date] TIMESTAMP,
)
​
CREATE TABLE transaction_product(
	transaction_id INT FOREIGN KEY REFERENCES cashbox_transaction(id),
	product_id INT FOREIGN KEY REFERENCES product(id),
	quantity INT,
	PRIMARY KEY (transaction_id, product_id)
)
​
CREATE TABLE cell_products(
	branch_id INT foreign key references branch(id),
	product_id INT foreign key references product(id),
	dep_quantity INT,
	optimal_quantity INT,
	max_quantity INT,
	PRIMARY KEY(branch_id, product_id)
)
​
CREATE TABLE dispose_package(
	id INT PRIMARY KEY IDENTITY,
	product_id INT FOREIGN KEY REFERENCES product(id),
	branch_id INT FOREIGN KEY REFERENCES branch(id),
	quantity INT,
	volume INT
)
​
CREATE TABLE logistics(
 	id INT PRIMARY KEY IDENTITY,
 	destination_branch_id INT FOREIGN KEY REFERENCES branch(id),
	starting_branch_id INT FOREIGN KEY REFERENCES branch(id),
 	product_id INT FOREIGN KEY REFERENCES product(id),

	quantity INT,
 	created_at datetime,
 	sent_at datetime,
 	arrived_at datetime,
)
​
CREATE TABLE shipping(
	id INT PRIMARY KEY IDENTITY,
	product_id INT FOREIGN KEY REFERENCES product(id),
	destination_branch_id INT FOREIGN KEY REFERENCES branch(id),
    supplier_id INT FOREIGN KEY REFERENCES supplier(id),
	
	quantity INT,
    created_at datetime,
	sent_at datetime,
	arrived_at datetime,
)
​
CREATE TABLE jobs(
	id INT PRIMARY KEY IDENTITY,
	[priority] INT,
    employee_id INT FOREIGN KEY REFERENCES users(id),
	[status] bit,
	[description] NVARCHAR(64),
)
CREATE TABLE warehouse_jobs(
	jobs_id INT FOREIGN KEY REFERENCES jobs(id),
	shipping_id INT FOREIGN KEY REFERENCES shipping(id),
	logistics_id INT FOREIGN KEY REFERENCES logistics(id),
	PRIMARY KEY (jobs_id)
)

CREATE TABLE warehouseToDepartment_jobs(
	jobs_id INT FOREIGN KEY REFERENCES jobs(id),
	product_id INT NOT NULL FOREIGN KEY REFERENCES product(id),
	quantity INT,
	PRIMARY KEY (jobs_id)
)
CREATE TABLE checkAndDispose_job(
	jobs_id INT FOREIGN KEY REFERENCES jobs(id),
	PRIMARY KEY (jobs_id)
)
CREATE TABLE product_package(
	id INT PRIMARY KEY IDENTITY,
	branch_id INT FOREIGN KEY REFERENCES branch(id),
	prod_id INT FOREIGN KEY REFERENCES product(id),
	warehouse_quantity INT,
	dep_quantity INT,
	expiration_date date,
	volume INT,
)
​
CREATE TABLE special_care(
	product_id INT FOREIGN KEY REFERENCES product(id),
	max_temp INT,
	min_temp INT,
	expiration_date datetime,
	PRIMARY KEY (product_id)
)
CREATE TABLE open_positions(
	id INT PRIMARY KEY IDENTITY,
	position_id INT FOREIGN KEY REFERENCES proffesion(id),
	[descrription] NVARCHAR(250),
)