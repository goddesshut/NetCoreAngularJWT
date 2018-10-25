import { Injectable } from "@angular/core";

@Injectable({ providedIn: "root" })
export class TokenService {
	private token = "token";

	clear() {
		sessionStorage.removeItem(this.token);
	}

	exists() {
		return this.get() !== null;
	}

    get(): string {
		return sessionStorage.getItem(this.token);
	}

    set(token: string) {
		sessionStorage.setItem(this.token, token);
	}
}
