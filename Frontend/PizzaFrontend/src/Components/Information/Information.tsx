import { ReactNode, useState } from "react";

import styles from "./Information.module.css"

import warning from "../../assets/WindowsTools/warning.png"

interface InformationProps {
    children: ReactNode  
}

const Information = ({children}: InformationProps) => {
    const [informationIsOpen, setInformationIsOpen] = useState(false);
    
    return (
        <div className={styles.main}>
            <div onClick={() => setInformationIsOpen(!informationIsOpen)} className={styles.openInformation}>
                <img src={warning} alt="warning" width={30}/>
            </div>
            <div className={styles.informationContent+ ` ${informationIsOpen ? styles.open : styles.close}`}>
                {
                    children
                }
            </div>
        </div>
    )
}

export default Information;