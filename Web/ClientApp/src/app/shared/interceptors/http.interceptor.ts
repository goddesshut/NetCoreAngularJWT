import { HttpHandler, HttpInterceptor, HttpRequest, HttpEvent } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { TokenService } from "../services/token.service";
import { Observable } from "rxjs";

@Injectable()
export class CustomHttpInterceptor implements HttpInterceptor {
	constructor(private readonly tokenService: TokenService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		let url = request.url;

		if (!url.startsWith("http")) {
			url = document.getElementsByTagName("base").item(0).href + url;
		}

		request = request.clone({
			setHeaders: { Authorization: `Bearer ${this.tokenService.get()}` },
			url
        });

        return next.handle(request);
	}
}
