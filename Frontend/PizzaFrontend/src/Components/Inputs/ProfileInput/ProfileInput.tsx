
import { useEffect, useState } from "react";
import styles from "./ProfileInput.module.css"
import Information from "../../Information/Information";

interface ProfileInputProps {
    label: string;
    additionalInfrom?: string
    value: string;
    readonly?: boolean;
    setValue?: React.Dispatch<React.SetStateAction<string>>;
    btnAction?: (e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => void;
    btnName?: string
}

// Todo readonly functionality
const ProfileInput = ({ label, value, additionalInfrom, readonly = false, setValue, btnAction, btnName }: ProfileInputProps) => {
    const [defaultValue, setDefaultValue] = useState<string>("");

    useEffect(() => {
        setDefaultValue(value);
    }, [])

    return (
        <div className={styles.main}>
            <div className={styles.header}>
                <p className={styles.inputName}>{label}</p>
                {
                    additionalInfrom &&
                    <Information sizeImg={20}>
                        <p className={styles.additionInformation}>{additionalInfrom}</p>
                    </Information>
                }
            </div>
            <div className={styles.dataWrapper}>
                <div className={styles.data}>
                    <input type="text" value={value} onChange={(e) => { if (setValue) setValue(e.target.value) }} />
                    <div className={styles.btnContainer}>
                        <button className={`${defaultValue == value ? "" : styles.valueChange}`} onClick={(e) => { if (btnAction) btnAction(e) }}>
                            {btnName}
                        </button>
                    </div>
                </div>
                <div className={styles.cancelBtnContainer + ` ${defaultValue == value ? styles.isHidden : styles.isVisible}`}>
                    <button onClick={() => { if (setValue) setValue(defaultValue) }}>Отменить</button>
                </div>
            </div>
        </div>
    )
}

export default ProfileInput;