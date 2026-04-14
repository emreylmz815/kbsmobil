# KbsMobile

Kurumsal saha/KBS kullanımına uygun, .NET MAUI tabanlı mobil istemci.

## Mimari
- MVVM + DI + Feature-based klasörleme.
- Katmanlar: `Core`, `Features`, `Services`, `Repositories`, `Platforms`, `Resources`.
- Harita çözümü: MAUI `WebView` içinde OpenLayers (WMS odaklı), servis bazlı katman yönetimi.
- Veri akışı: View -> ViewModel -> Service -> Repository/API.

## Güncel Akış (İstenen UX)
1. Uygulama açılışında **Splash -> Login** akışı çalışır.
2. Başarılı giriş sonrası kullanıcı doğrudan **Harita** sekmesine geçer.
3. Harita varsayılan olarak **Düzce merkez** koordinatlarına odaklanır.
4. Harita ekranında:
   - Sol açılır menü: **Haritalar, Katmanlar, Profil, Çıkış Yap**
   - Sağ açılır menü: Daha önceki kayıtlar listesi + seçili kayıt detay kartı
5. Sağ karttaki **Haritada Göster** butonu menüleri kapatır ve ilgili kayda zoom yapar.

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
