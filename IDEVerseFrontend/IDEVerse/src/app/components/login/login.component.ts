import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { first } from "rxjs/operators";
import { AuthenticationService } from "src/app/services/authentication.service";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
  loading = false;
  submitted = false;
  returnUrl: string;
  error: string;
  success: string;
  login: string;
  password: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService,
    private authenticationService: AuthenticationService
  ) {
    // redirect to home if already logged in
    if (this.authenticationService.currentUserValue) {
      this.router.navigate(["/"]);
    }
  }

  ngOnInit() {
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams["returnUrl"] || "/";

    // show success message on registration
    if (this.route.snapshot.queryParams["registered"]) {
      this.success = "Registration successful";
    }
  }

  onSubmit(event) {
    this.submitted = true;

    // reset alerts on submit
    this.error = null;
    this.success = null;

    // stop here if form is invalid

    this.loading = true;
    this.authenticationService
      .login(this.login, this.password)
      .pipe(first())
      .subscribe(
        (data) => {
          this.router.navigate([this.returnUrl]);
        },
        (error) => {
          this.toastr.error(error);
          this.error = error;
          this.loading = false;
        }
      );
  }
}
