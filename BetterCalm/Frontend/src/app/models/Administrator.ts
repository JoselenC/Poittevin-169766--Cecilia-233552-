export class Administrator {
  administratorId: number;
  name ?: string;
  lastName ?: string;
  email ?: string;
  password ?: string;
  token ?: string;

  constructor(
    administratorId: number,
    email ?: string,
    password ?: string,
    name ?: string,
    lastName ?: string,
    token ?: string,
  ) {
    this.administratorId = administratorId;
    this.email = email;
    this.password = password;
    this.name = name;
    this.lastName = lastName;
    this.token = token;
  }
}
