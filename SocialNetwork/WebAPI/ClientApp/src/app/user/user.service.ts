import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User} from './User';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private fb: FormBuilder) { }
  
  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    FirstName: [''],
    LastName: [''],
    Age: [''],
    PhoneNumber: [''],
    City:[''],
    Country:[''],
    University:[''],
    AboutMe:[''],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords })
  });

  
  
    getUserByIdObservable (id: number){
      return this.http.get<User>(this.baseUrl+'api/users/'+id);
    }

    getUsersObservable (){
      return this.http.get<User[]>(this.baseUrl+'api/users');
    }

    // addHero(hero: Hero): Observable<Hero> {
    //   return this.http.post<Hero>(this.heroesUrl, hero, httpOptions)
    //     .pipe(
    //       catchError(this.handleError('addHero', hero))
    //     );
    // }
    updateUser(user: User) {
      user.id = 1;
      return this.http.patch<User>(this.baseUrl+'api/users', user);
      //return this.http.put<User>(this.baseUrl+'api/users', user);
        // .pipe(
        //  catchError(er => {console.log(er)})
        // );
    }
    deleteUser(id){
      return this.http.delete<User>(this.baseUrl+'api/users/'+id);
    }
   
    getUserProfile() {
      return this.http.get(this.baseUrl + '/UserProfile');
    }
    register(){
      var body = {
        UserName: this.formModel.value.UserName,
        Email: this.formModel.value.Email,
        FullName: this.formModel.value.FullName,
        Password: this.formModel.value.Passwords.Password,
        Role: "user"
      };
      return this.http.post(this.baseUrl + 'api/account/register', body);
    }

    login(model: User){
      return this.http.post(this.baseUrl + 'api/account/login', model);
    }

    roleMatch(allowedRoles): boolean {
      var isMatch = false;
      var payLoad = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1]));
      var userRole = payLoad.role;
      allowedRoles.forEach(element => {
        if (userRole == element) {
          isMatch = true;
          return false;
        }
      });
      return isMatch;
    }

  comparePasswords(fb: FormGroup) {
    let confirmPswrdCtrl = fb.get('ConfirmPassword');
    //passwordMismatch
    //confirmPswrdCtrl.errors={passwordMismatch:true}
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password').value != confirmPswrdCtrl.value)
        confirmPswrdCtrl.setErrors({ passwordMismatch: true });
      else
        confirmPswrdCtrl.setErrors(null);
    }
  }

}
  