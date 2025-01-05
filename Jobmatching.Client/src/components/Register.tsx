import styles from "./Register.module.css";

type AccountType = "Candidate" | "Employer";

const accountOptions: { id: string; value: AccountType }[] = [
  { id: "CAN", value: "Candidate" },
  { id: "EMP", value: "Employer" },
];

export default function Register() {
  function onSubmitHandler(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();
  }

  return (
    <form
      method="post"
      className={styles.registrationForm}
      onSubmit={(e) => onSubmitHandler(e)}
    >
      <div className={styles.registrationForm__group}>
        <label htmlFor="userName">Username</label>
        <input
          id="userName"
          type="text"
          placeholder="Username"
          className={styles.registrationForm__input}
        />
      </div>
      <div className={styles.registrationForm__group}>
        <label htmlFor="firstName">First name</label>
        <input
          id="firstName"
          type="text"
          placeholder="First name"
          className={styles.registrationForm__input}
        />
      </div>
      <div className={styles.registrationForm__group}>
        <label htmlFor="lastName">Last name</label>
        <input
          id="lastName"
          type="text"
          placeholder="Last name"
          className={styles.registrationForm__input}
        />
      </div>
      <div className={styles.registrationForm__group}>
        <label htmlFor="password">Password</label>
        <input
          id="password"
          type="password"
          placeholder="Password"
          className={styles.registrationForm__input}
        />
      </div>
      <div className={styles.registrationForm__group}>
        <label htmlFor="email">Email</label>
        <input
          id="email"
          type="email"
          placeholder="Email"
          className={styles.registrationForm__input}
        />
      </div>
      <div className={styles.registrationForm__group}>
        <label htmlFor="userType">Email</label>
        <select id="userType" className={styles.registrationForm__dropDown}>
          {accountOptions.map((o) => (
            <option id={o.id}>{o.value}</option>
          ))}
        </select>
      </div>
      <div className={styles.registrationForm__group}>
        <button className="btn btn-primary">Register</button>
      </div>
    </form>
  );
}
