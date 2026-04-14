# KbsMobile

Kurumsal saha/KBS kullanımına uygun, .NET MAUI tabanlı mobil istemci.

## Mimari
- MVVM + DI + Feature-based klasörleme.
- Katmanlar: `Core`, `Features`, `Services`, `Repositories`, `Platforms`, `Resources`.
- Harita çözümü: MAUI `WebView` içinde OpenLayers (WMS odaklı), servis bazlı katman yönetimi.
- Veri akışı: View -> ViewModel -> Service -> Repository/API.

## Temel Modüller
1. Authentication (login/splash/logout)
2. Dashboard
3. Map + WMS + Layer management
4. Records CRUD
5. Form + validasyon
6. Media capture/pick
7. Location
8. Error/logging

## Mock'tan Gerçek API'ye Geçiş
- `MockAuthService` yerine API tabanlı servis implementasyonu ekleyin.
- `MockRecordRepository` ve `MockWmsLayerRepository` yerine `ApiClient` kullanan repository'ler yazın.
- DI kayıtlarında mock servisleri gerçek servislerle değiştirin.

## Test Stratejisi
- Unit test: ViewModel command davranışları, form validasyonları, layer toggle.
- Integration test: `IApiClient` ve repository bağlayıcıları.
- UI smoke test: login, map load, record CRUD akışı.

## Android Release
1. `dotnet publish -f net8.0-android -c Release /p:AndroidPackageFormat=aab`
2. Keystore üretimi: `keytool -genkeypair ...`
3. Signing bilgilerini CI secret veya secure store'dan besleyin.
4. Network security config gerekiyorsa production hostlar için pinning/allowlist kullanın.

## Publish Checklist
- [ ] API URL production'a alındı.
- [ ] TLS ve auth token yaşam süresi doğrulandı.
- [ ] Crash ve telemetry entegrasyonu (AppCenter/Sentry) açıldı.
- [ ] Android izin akışı saha senaryolarında test edildi.
- [ ] Performans: harita katman aç/kapa ve liste ekranı ölçümlendi.
