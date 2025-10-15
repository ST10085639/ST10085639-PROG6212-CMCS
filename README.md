# PROGRAMMING 2B PART 1

---

**Student Number:**  
ST10085639  

**Programme Code:**  
BCAD2  

**Module Lecturer:**  
Courteney Young  

**Module Code:**  
PROG6212  

**Date of Submission:**  
15-09-2025  

---

## The Documentation

For the academics who serve as independent contractors (ICs), the Contract Monthly Claim System (CMCS) is an important tool for improving the difficult task of submitting and approving monthly claims (Microsoft, 2023). The CMCS provides you with hands-on training with C# programming and .NET GUI development which bases itself on real-world workplace incidents (Microsoft, 2023).

Based on its dual purpose as an academic project and a functioning system, CMCS is created to help students improve their software development skills while solving real-world problems at the same time (Microsoft, 2023).

---

## The Explanation of Design Choices

The User-Centric Design provides easy-to-use navigation and extra features for submitting claims and reviewing them (Emma, 2024). Thus, benefitting academic managers, program coordinators, IC professors and lastly users with disabilities (Emma, 2024). Many user groups can benefit from this design:

- Academic managers (Emma, 2024).  
- The program coordinators (Emma, 2024).  
- The lecturers, known as the independent contractors (IC) (Emma, 2024).  
- Users that need accessibility (Emma, 2024).  

**Security:**  
The system will use encryption to protect sensitive information, especially personal information and finances (Frontegg, 2024). Role-based access control as well as multi-factor authentication are going to be applied to protect user accounts, and claims will be reviewed by lecturers, program coordinators and the academic management for safety reasons (Frontegg, 2024).

**Scalability and Maintainability:**  
Multiple databases that have front-end and back-end features are built into the CMCS system to ensure scalability and maintainability by carrying out easy upgrades and fast integration of new features (Ram, 2023).

---

## The Database Structure

The relational model used in the database supports SQL servers, and it’s supported in .NET systems (Microsoft Learn, 2024). The structure includes many important tables:

- **Users:**  
  Uses the user’s username, password, user_id and position (Manager, Coordinator or Lecturer), stored for system management needs (Microsoft Learn, 2024).

- **Lecturers:**  
  Uses the lecturer’s ID, first name and surname, hourly rate and the link to the Users table via the user ID (Microsoft Learn, 2024). Organized and easy to access lecturer-specific data (Microsoft Learn, 2024).

- **Claims:**  
  Stores lecturer claims by creating a connection with the Lecturers database via Claims_id (Microsoft Learn, 2024). Contains data like the month, year, hours worked as well as the status (Submitted, Reviewed, Approved and Rejected) (Microsoft Learn, 2024).

- **Supporting Documents:**  
  Corresponds to the claim support and is tracked in this table (Microsoft Learn, 2024). The foreign key connects the document to the Claims table, and each one is identified by document_id (Microsoft Learn, 2024).

- **Approval:**  
  Contains the claim approval information with the approval_id (Microsoft Learn, 2024). It includes the approval date, approver comments, and the foreign keys connected to the Claims and Users tables (Microsoft Learn, 2024).

---

## Assumptions

- Academic institutions use the CMCS to handle claims from independent contractors (IC) (Indeed, 2025).  
- Lecturers are paid monthly based on the hours they worked (Indeed, 2025).  
- Users should have basic computer skills and experience in web applications (Indeed, 2025).  
- Before final approval, claims are constantly reviewed by managers and coordinators (Indeed, 2025).

---

## Constraints

- The system must comply with data protection laws such as the GDPR to protect financial and personal data (Microsoft Security, 2025).  
- It must handle large amounts of claims, especially at month-end (Microsoft Security, 2025).  
- Accessibility must be ensured across all devices, including for users with disabilities (Microsoft Security, 2025).  
- Users in low-coverage areas are limited by their internet connection reliability (Microsoft Security, 2025).

---

## Conclusion

The Contract Monthly Claim System (CMCS) improves the administrative process by reducing manual claim handling through its easy-to-use interface (Microsoft Learn, 2015). It provides C# development training, improving students’ skills and tackling real-world problems in the evolving software development sector (Microsoft Learn, 2015).

---

## The UML Diagram

![UML](https://github.com/user-attachments/assets/62434226-8b41-4685-9276-b0c85d21412e)

(Microsoft Support, 2025)

---

## The Project Plan

![PP](https://github.com/user-attachments/assets/15f4bb51-17c9-48d3-ae30-23de5d491237)

(Awati, 2024)

---

## The GUI/UI

**Figure 1:** Sign Up Page

<img width="883" height="660" alt="SignUp" src="https://github.com/user-attachments/assets/c16a1169-683f-450f-a9d3-dfc935e12664" />

**Purpose:** Enables new users to register for a CMCS account by submitting their details and selecting their role.  

**Functions:**  
- **Input Fields:** Collects user information including first name, last name, email address, password, and confirmation password.  
- **Role Selection:** Allows users to choose their system role (e.g., Academic Manager, Program Coordinator, Lecturer, HR).  
- **Sign-Up Button:** Submits the registration form to create a new account in the system.  
- **Login Redirect:** Provides a link for users who already have an account.  
- **Navigation Bar:** Maintains a consistent design and allows smooth navigation across the CMCS platform.  

(Figma, 2025)

**Figure 2:** Login Page 

<img width="892" height="657" alt="Login" src="https://github.com/user-attachments/assets/ed4b02db-8bab-43f2-8521-880c8b063d08" />

**Purpose:** Allows registered users to securely access their CMCS account by verifying their credentials.  

**Functions:**  
- **Email & Password Fields:** Users enter their registered credentials (passwords are masked for security).  
- **Login Button:** Authenticates credentials and redirects users to the appropriate dashboard or homepage.  
- **Sign-Up Link:** Directs new users to the registration page.  
- **Navigation Bar:** Provides quick access to other pages (Home, Submit Claims, Claim History, etc.) and shows a Logout button once logged in.  

(Figma, 2025)

**Figure 3:** Home Page  

<img width="887" height="660" alt="Home" src="https://github.com/user-attachments/assets/03b01868-66d4-4cf2-973d-dbac00dbeed2" />

**Purpose:** Serves as the landing page after login, welcoming users to the Claims Management and Control System (CMCS).  

**Functions:**  
- Provides navigation to all major sections (Submit Claims, Claim History, Admin Dashboard, HR Dashboard).  
- Displays general announcements or system updates.  
- Sign-Up & Login buttons.

(Figma, 2025)

**Figure 4:** Submit Claims Page

<img width="886" height="655" alt="Submit Claims" src="https://github.com/user-attachments/assets/258085a9-f6cf-4e2e-85b9-7ca8894e4f9d" />

**Purpose:** Allows users to submit new claim requests. Only Lecturers can access.  

**Functions:**  
- Users can enter claim details such as claim type, amount, and reason.  
- Upload supporting documents (PDF, images, or receipts).  
- Submit button stores the claim in the system database for admin review.

(Figma, 2025)

**Figure 5:** Claim History Page 

<img width="889" height="662" alt="Claim History" src="https://github.com/user-attachments/assets/4260607c-7101-4c34-87a5-15b4243079bc" />

**Purpose:** Displays a record of all submitted claims by the user. Only Lecturers can access.  

**Functions:**  
- Shows claim details such as claim ID, submission date, claim amount, and current status (Pending, Approved, or Rejected).  
- Helps users track the progress of each claim over time.
- Download documents.   

(Figma, 2025)

**Figure 6:** Admin Dashboard Page  

<img width="885" height="662" alt="Admin Dashboard" src="https://github.com/user-attachments/assets/d96a8788-a808-4ea4-b1c3-bacfe1d94227" />

**Purpose:** Provides administrative tools for managing and reviewing claims. Only Admin can access.  

**Functions:**  
- Displays all claims from users with their details.  
- Admins can update each claim’s status (Approved, Pending, Rejected).  
- Download documents. 

(Figma, 2025)

**Figure 7:** HR Dashboard Page 

<img width="888" height="655" alt="HR Dashboard" src="https://github.com/user-attachments/assets/0d746c67-72c0-4128-b9e4-ad47f4e07edb" />

**Purpose:** Displays HR-related claim documents and contracts for review or download. Only HR can access.  

**Functions:**  
- Lists all available claim contracts (e.g., ClaimsDocument.pdf, ClaimsDocument2.pdf, etc.).  
- Each document has an Open button that allows users to download or view the file.  
- Provides easy access to important HR-related PDFs for recordkeeping.  

(Figma, 2025)

---

### Figma Link  
[https://www.figma.com/design/vUmzAj6queQJHisxrIMfvP/CMCS-Part-1?t=oGL0D8tsxlo675ZF-0](https://www.figma.com/design/vUmzAj6queQJHisxrIMfvP/CMCS-Part-1?t=oGL0D8tsxlo675ZF-0)

### GitHub Link  
[https://github.com/ST10085639/ST10085639-PROG6212-CMCS](https://github.com/ST10085639/ST10085639-PROG6212-CMCS)

---

## Reference List

Awati, R. 2024. *Project planning: What it is and 5 steps to create a plan*, 23 August 2024. [Online].  
Available at: https://www.techtarget.com/searchcio/definition/project-planning  
[Accessed 4 September 2025].

Emma, L. 2024. *User-centered design to enhance accessibility and usability in digital systems*, 2 December 2024. [Online].  
Available at: https://www.researchgate.net/publication/386339454_User-centered_design_to_enhance_accessibility_and_usability_in_digital_systems  
[Accessed 4 September 2025].

Figma. 2025. *Figma*, 4 September 2025. [Online].  
Available at: https://www.figma.com/design/vUmzAj6queQJHisxrIMfvP/CMCS-Part-1?t=oGL0D8tsxlo675ZF-0  
[Accessed 4 September 2025].

Frontegg. 2024. *Access Control in Security: Methods and Best Practices*, 7 February 2024. [Online].  
Available at: https://frontegg.com/guides/access-control-in-security  
[Accessed 4 September 2025].

Indeed. 2025. *Everything You Need to Know About Majoring in Computer Science*, 28 March 2025. [Online].  
Available at: https://ca.indeed.com/career-advice/career-development/everything-you-need-to-know-about-majoring-in-computer-science  
[Accessed 4 September 2025].

Microsoft Learn. 2015. *C# Best Practices: Dangers of Violating SOLID Principles in C#*, 7 January 2015. [Online].  
Available at: https://learn.microsoft.com/en-us/archive/msdn-magazine/2014/may/csharp-best-practices-dangers-of-violating-solid-principles-in-csharp  
[Accessed 4 September 2025].

Microsoft. 2023. *Claims-based authorization in ASP.NET Core*, 11 October 2023. [Online].  
Available at: https://learn.microsoft.com/en-us/aspnet/core/security/authorization/claims?view=aspnetcore-9.0  
[Accessed 4 September 2025].

Microsoft Learn. 2024. *Databases*, 22 November 2024. [Online].  
Available at: https://learn.microsoft.com/en-us/sql/relational-databases/databases/databases?view=sql-server-ver17  
[Accessed 4 September 2025].

Microsoft Security. 2025. *What is GDPR compliance?*, 2025. [Online].  
Available at: https://www.microsoft.com/en-za/security/business/security-101/what-is-gdpr-compliance  
[Accessed 4 September 2025].

Microsoft Support. 2025. *Create a UML class diagram*, 2025. [Online].  
Available at: https://support.microsoft.com/en-us/office/create-a-uml-class-diagram-de6be927-8a7b-4a79-ae63-90da8f1a8a6b  
[Accessed 4 September 2025].

Ram, M. 2023. *Frontend Development for Scalability: Building Robust and Maintainable Code*, 11 July 2023. [Online].  
Available at: https://medium.com/@mukesh.ram/frontend-development-for-scalability-building-robust-and-maintainable-code-f599425ced03  
[Accessed 4 September 2025].
