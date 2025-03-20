using System.Threading.Tasks;
using UnityEngine;

namespace DesignPatterns.Bridge
{
    public class GrowEffect : IWeaponEffect
    {
        Transform _weaponObject;
        Material _weaponMaterial;
        Color _originalColor;
        private Color _effectColor = new Color(0.4f, 0.6f, 0.1f);

        public GrowEffect(Transform weaponObject, Material weaponMaterial)
        {
            _weaponObject = weaponObject;
            _weaponMaterial = weaponMaterial;
            _originalColor = _weaponMaterial.color;
        }

        public void PlayEffect()
        {
            PlayAsyncEffect();
        }

        async Task GrowEffectAsync()
        {
            float totalTime = 0.8f;
            float halfTime = totalTime / 2;
            float elapsedTime = 0;
            float value;
            Vector3 originalScale = _weaponObject.localScale;
            Vector3 newScale = originalScale * 1.5f;


            while (elapsedTime / halfTime <= 1.0f)
            {
                elapsedTime += Time.deltaTime;
                value = elapsedTime / halfTime;

                _weaponObject.localScale = Vector3.Lerp(originalScale, newScale, value);
                _weaponMaterial.color = Color.Lerp(_originalColor, _effectColor, value);
                await Task.Yield();
            }

            _weaponObject.localScale = newScale;
            _weaponMaterial.color = _effectColor;

            elapsedTime = 0;
            while (elapsedTime / halfTime <= 1.0f)
            {
                elapsedTime += Time.deltaTime;
                value = elapsedTime / halfTime;

                _weaponObject.localScale = Vector3.Lerp(newScale, originalScale, value);
                _weaponMaterial.color = Color.Lerp(_effectColor, _originalColor, value);
                await Task.Yield();
            }

            _weaponObject.localScale = originalScale;
            _weaponMaterial.color = _originalColor;
        }

        async void PlayAsyncEffect()
        {
            await GrowEffectAsync();
        }
    }

}